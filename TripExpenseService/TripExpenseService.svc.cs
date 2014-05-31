using System.Collections.Generic;
using Business;
using Entities.Implementation;

namespace TripExpenseService
{
	public class Service : IService
	{
		private readonly ITripCore tripCore;

		public Service()
		{
			tripCore = new TripCore();
		}

		public void AddOrUpdateUser(User user)
		{
			tripCore.AddOrUpdate(user);
		}

		public void AddOrUpdateTrip(Trip trip)
		{
			tripCore.AddOrUpdate(trip);
		}

		public void AddOrUpdateExpense(Expense expense, string tripId)
		{
			tripCore.AddOrUpdate(expense, tripId);
		}

		public void AddOrUpdateCourse(Rate rate, string tripId)
		{
			tripCore.AddOrUpdate(rate, tripId);
		}

		public void AddOrUpdatePayInfo(PayInfo payInfo, string expenseId)
		{
			tripCore.AddOrUpdate(payInfo, expenseId);
		}

		public IEnumerable<Rate> GetCourses(string tripId)
		{
			return tripCore.GetCourses(tripId);
		}

		public IEnumerable<Expense> GetExpenses(string tripId)
		{
			return tripCore.GetExpenses(tripId);
		}

		public IEnumerable<Trip> GetTrips(string userId)
		{
			return tripCore.GetTrips(userId);
		}
	}
}