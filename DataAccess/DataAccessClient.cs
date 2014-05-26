using System;
using System.Collections.Generic;
using DataAccess.Builders;
using DataAccess.Entities;
using DataAccess.Entities.Interfaces;
using DataAccess.Exceptions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

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

		public void AddOrUpdate<T>(T entity) where T : IIdentityObject
		{
			MongoCollection<T> collection = MongoDatabase.GetCollection<T>(collectionNames[entity.GetType()]);
			CheckResult(collection.Save(entity));
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

		private void InitCollectionDictionary()
		{
			collectionNames.Add(typeof(UserDTO), "Users");
			collectionNames.Add(typeof(TripDTO), "Trips");
			collectionNames.Add(typeof(CourseDTO), "Courses");
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