using System.Collections.Generic;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class ExpenseManager : BaseManager
	{
		public void AddOrUpdate(Expense expense, string tripId)
		{
			TripDTO tripDTO = DataAccessClient.Get<TripDTO>(tripId);
			ExpenseDTO expenseDTO = EntityConverter.ConvertExpense(expense);

			tripDTO.ExpenseDTOs.Add(expenseDTO);

			DataAccessClient.AddOrUpdate(expenseDTO);
		}

		public List<Expense> GetExpenses(string tripId)
		{
			throw new System.NotImplementedException();
		}
	}
}