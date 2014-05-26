using System.Collections.Generic;
using Business.Managers.Implementation;
using Entities.Implementation;

namespace Business
{
	public class TripCore : ITripCore
	{
		private readonly TripManager tripManager = new TripManager();
		private readonly UserManager userManager = new UserManager();
		private readonly CourseManager courseManager = new CourseManager();
		private readonly PayInfoManager payInfoManager = new PayInfoManager();
		private readonly ExpenseManager expenseManager = new ExpenseManager();

		public void AddOrUpdate(User user)
		{
			userManager.AddOrUpdate(user);
		}

		public void AddOrUpdate(Trip trip)
		{
			tripManager.AddOrUpdate(trip);
		}

		public void AddOrUpdate(Expense expense, string tripId)
		{
			expenseManager.AddOrUpdate(expense, tripId);
		}

		public void AddOrUpdate(Course course, string tripId)
		{
			courseManager.AddOrUpdate(course, tripId);
		}

		public void AddOrUpdate(PayInfo payInfo, string expenseId)
		{
			payInfoManager.AddOrUpdate(payInfo, expenseId);
		}

		public List<Trip> GetTrips(string userId)
		{
			return tripManager.GetTrips(userId);
		}

		public List<Expense> GetExpenses(string tripId)
		{
			return expenseManager.GetExpenses(tripId);
		}

		public List<Course> GetCourses(string tripId)
		{
			return courseManager.GetCourses(tripId);
		}
	}
}