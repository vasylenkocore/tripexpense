using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class TripManager : BaseManager
	{
		public void AddOrUpdate(Trip trip)
		{
			TripDTO tripDTO = EntityConverter.Convert(trip);

			DataAccessClient.AddOrUpdate(tripDTO);
		}

		public IEnumerable<Trip> GetTrips(string userId)
		{
			IEnumerable<TripDTO> trips = DataAccessClient.GetTrips(userId);

			return trips.Select(t => EntityConverter.Convert(t));
		}

		public Trip GetTrip(string tripId)
		{
			TripDTO tripDTO = DataAccessClient.Get<TripDTO>(tripId);

			return EntityConverter.Convert(tripDTO);
		}
	}
}