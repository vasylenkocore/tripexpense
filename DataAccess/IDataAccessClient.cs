using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Entities.Interfaces;

namespace DataAccess
{
	public interface IDataAccessClient
	{
		T AddOrUpdate<T>(T entity) where T : IIdentityObject;

		void Delete<T>(string id) where T : IIdentityObject;

		T Get<T>(string id) where T : IIdentityObject;

		IEnumerable<RateDTO> GetRates(string tripId);

		IEnumerable<TripDTO> GetTrips(string userId);
	}
}