using System.Collections.Generic;
using Business.Managers.Implementation;
using Entities.Implementation;

namespace Business
{
	public class TripCore : ITripCore
	{
		private readonly TripManager tripManager = new TripManager();
		private readonly UserManager userManager = new UserManager();
		private readonly RateManager rateManager = new RateManager();
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

		public void AddOrUpdate(Rate rate, string tripId)
		{
			rateManager.AddOrUpdate(rate, tripId);
		}

		public void AddOrUpdate(PayInfo payInfo, string expenseId)
		{
			payInfoManager.AddOrUpdate(payInfo, expenseId);
		}

		public IEnumerable<Trip> GetTrips(string userId)
		{
			return tripManager.GetTrips(userId);
		}

		public IEnumerable<Expense> GetExpenses(string tripId)
		{
			return expenseManager.GetExpenses(tripId);
		}

		public IEnumerable<Rate> GetCourses(string tripId)
		{
			return rateManager.GetRates(tripId);
		}
	}
}