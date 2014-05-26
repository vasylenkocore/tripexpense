using System.Collections.Generic;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class TripManager : BaseManager
	{
		public void AddOrUpdate(Trip trip)
		{
			TripDTO tripDTO = EntityConverter.ConvertTrip(trip);

			DataAccessClient.AddOrUpdate(tripDTO);
		}

		public List<Trip> GetTrips(string userId)
		{
			throw new System.NotImplementedException();
		}
	}
}