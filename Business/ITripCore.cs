using System.Collections.Generic;
using Entities.Implementation;

namespace Business
{
	public interface ITripCore
	{
		void AddOrUpdate(User user);

		void AddOrUpdate(Trip trip);

		void AddOrUpdate(Expense expense, string tripId);

		void AddOrUpdate(Course expense, string tripId);

		void AddOrUpdate(PayInfo user, string expenseId);

		List<Trip> GetTrips(string userId);

		List<Expense> GetExpenses(string tripId);

		List<Course> GetCourses(string tripId);
	}
}