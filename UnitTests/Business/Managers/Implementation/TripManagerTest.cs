using System.Collections.Generic;
using System.Linq;
using Business.Managers.Implementation;
using DataAccess.Entities;
using Entities.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.DataAccess;

namespace UnitTests.Business.Managers.Implementation
{
	[TestClass]
	public class TripManagerTest
	{
		[TestMethod]
		public void GetTripsTest()
		{
			DataAccessClientTest dataAccessClientTest = new DataAccessClientTest();
			dataAccessClientTest.FillTrip(Target);
		}

		private void Target(TripDTO trip)
		{
			TripManager tripManager = new TripManager();
			IEnumerable<Trip> trips = tripManager.GetTrips(trip.UserIds.First());

			Assert.AreEqual(trip.Id, trips.First().Id);
		}
	}
}