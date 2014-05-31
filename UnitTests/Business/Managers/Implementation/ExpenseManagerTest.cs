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
	public class ExpenseManagerTest
	{
		[TestMethod]
		public void GetTripsTest()
		{
			DataAccessClientTest dataAccessClientTest = new DataAccessClientTest();
			dataAccessClientTest.FillTrip(Target);
		}

		private void Target(TripDTO trip)
		{
			ExpenseManager expenseManager = new ExpenseManager();
			IEnumerable<Expense> expenses = expenseManager.GetExpenses(trip.Id);

			Assert.AreEqual(expenses.Count(), 2);
		}
	}
}