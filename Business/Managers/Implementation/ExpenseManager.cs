using System.Collections.Generic;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class ExpenseManager : BaseManager
	{
		private readonly TripManager tripManager = new TripManager();

		public void AddOrUpdate(Expense expense, string tripId)
		{
			TripDTO tripDTO = DataAccessClient.Get<TripDTO>(tripId);
			ExpenseDTO expenseDTO = EntityConverter.Convert(expense);

			tripDTO.ExpenseDTOs.Add(expenseDTO);

			DataAccessClient.AddOrUpdate(expenseDTO);
		}

		public IEnumerable<Expense> GetExpenses(string tripId)
		{
			Trip trip = tripManager.GetTrip(tripId);
			return trip.Expenses;
		}
	}
}