using System;
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
	public class RateManagerTest
	{
		[TestMethod]
		public void AddOrUpdateTest()
		{
			Rate rate = new Rate("UAH", "USD", 11.98);
			RateManager rateManager = new RateManager();
			Rate savedRate = null;
			try
			{
				string tripId = Guid.NewGuid().ToString();

				savedRate = rateManager.AddOrUpdate(rate, tripId);
				Rate rateFromDb = rateManager.GetCourse(savedRate.Id);

				Assert.IsNotNull(rateFromDb);
			}
			finally
			{
				rateManager.Delete(savedRate);

				if (savedRate != null)
				{
					Rate rateFromDb = rateManager.GetCourse(savedRate.Id);
					Assert.IsNull(rateFromDb);
				}
			}
		}

		[TestMethod]
		public void GetRatesTest()
		{
			DataAccessClientTest dataAccessClientTest = new DataAccessClientTest();
			dataAccessClientTest.FillTrip(Target);
		}

		private void Target(TripDTO trip)
		{
			RateManager rateManager = new RateManager();
			IEnumerable<Rate> rates = rateManager.GetRates(trip.Id);
			Assert.AreEqual(rates.Count(), 2);
		}
	}
}