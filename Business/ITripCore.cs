using System.Collections.Generic;
using Entities.Implementation;

namespace Business
{
	public interface ITripCore
	{
		void AddOrUpdate(User user);

		void AddOrUpdate(Trip trip);

		void AddOrUpdate(Expense expense, string tripId);

		void AddOrUpdate(Rate expense, string tripId);

		void AddOrUpdate(PayInfo user, string expenseId);

		IEnumerable<Trip> GetTrips(string userId);

		IEnumerable<Expense> GetExpenses(string tripId);

		IEnumerable<Rate> GetCourses(string tripId);
	}
}