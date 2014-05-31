using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Builders;
using DataAccess.Entities;
using DataAccess.Entities.Interfaces;
using DataAccess.Exceptions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace DataAccess
{
	public class DataAccessClient : IDataAccessClient
	{
		private const string DatabaseName = "tripexpense";

		private readonly Dictionary<Type, string> collectionNames = new Dictionary<Type, string>(); 

		public DataAccessClient()
		{
			InitCollectionDictionary();

			MongoServerBuilder serverBuilder = new MongoServerBuilder();
			MongoServer mongoServer = serverBuilder.Build();
			MongoDatabase = mongoServer.GetDatabase(DatabaseName);
		}

		private MongoDatabase MongoDatabase { get; set; }

		public T AddOrUpdate<T>(T entity) where T : IIdentityObject
		{
			MongoCollection<T> collection = MongoDatabase.GetCollection<T>(collectionNames[entity.GetType()]);
			CheckResult(collection.Save(entity));
			return Get<T>(entity.Id);
		}

		public void Delete<T>(string id) where T : IIdentityObject
		{
			MongoCollection<T> collection = MongoDatabase.GetCollection<T>(collectionNames[typeof(T)]);

			IMongoQuery query = Query<T>.EQ(entity => entity.Id, id);

			if (query != null)
			{
				CheckResult(collection.Remove(query));
			}
		}

		public T Get<T>(string id) where T : IIdentityObject
		{
			MongoCollection<T> collection = MongoDatabase.GetCollection<T>(collectionNames[typeof(T)]);

			IMongoQuery query = Query.And(Query<UserDTO>.EQ(entity => entity.Id, id));

			return collection.FindOne(query);
		}

		public IEnumerable<RateDTO> GetRates(string tripId)
		{
			MongoCollection<RateDTO> ratesMongoCollection =
				MongoDatabase.GetCollection<RateDTO>(collectionNames[typeof(RateDTO)]);

			IQueryable<RateDTO> query = ratesMongoCollection.AsQueryable().Where(e => e.TripId == tripId);

			return query.ToList();
		}

		public IEnumerable<TripDTO> GetTrips(string userId)
		{
			MongoCollection<TripDTO> tripsMongoCollection =
				MongoDatabase.GetCollection<TripDTO>(collectionNames[typeof(TripDTO)]);

			IQueryable<TripDTO> query = tripsMongoCollection.AsQueryable().Where(e => e.UserIds.Contains(userId));

			return query.ToList();
		}

		private void InitCollectionDictionary()
		{
			collectionNames.Add(typeof(UserDTO), "Users");
			collectionNames.Add(typeof(TripDTO), "Trips");
			collectionNames.Add(typeof(RateDTO), "Rates");
		}

		private void CheckResult(CommandResult result)
		{
			if (!result.Ok)
			{
				throw new MongoWriteException(result.ErrorMessage);
			}
		}
	}
}