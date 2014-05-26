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

		public void AddOrUpdateCourse(Course course, string tripId)
		{
			tripCore.AddOrUpdate(course, tripId);
		}

		public void AddOrUpdatePayInfo(PayInfo payInfo, string expenseId)
		{
			tripCore.AddOrUpdate(payInfo, expenseId);
		}

		public List<Course> GetCourses(string tripId)
		{
			return tripCore.GetCourses(tripId);
		}

		public List<Expense> GetExpenses(string tripId)
		{
			return tripCore.GetExpenses(tripId);
		}

		public List<Trip> GetTrips(string userId)
		{
			return tripCore.GetTrips(userId);
		}
	}
}