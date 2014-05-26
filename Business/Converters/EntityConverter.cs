using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Converters
{
	internal class EntityConverter : IEntityConverter
	{
		public UserDTO ConvertUser(User user)
		{
			UserDTO userDTO = new UserDTO(user.Id, user.Name, user.Password, user.PhoneNumber, user.Email);
			return userDTO;
		}

		public TripDTO ConvertTrip(Trip trip)
		{
			List<string> userIds = trip.Users.Select(user => user.Id).ToList();
			List<ExpenseDTO> expenses = trip.Expenses.Select(ConvertExpense).ToList();

			TripDTO tripDTO = new TripDTO(trip.Id, trip.Name, trip.Description, userIds, expenses);

			return tripDTO;
		}

		public ExpenseDTO ConvertExpense(Expense expense)
		{
			List<PayInfoDTO> payments = expense.PaidInfo.Select(ConvertPayInfo).ToList();

			ExpenseDTO expenseDTO = new ExpenseDTO(expense.Id, expense.Name, expense.Description, payments);

			return expenseDTO;
		}

		public PayInfoDTO ConvertPayInfo(PayInfo payInfo)
		{
			PayInfoDTO payInfoDTO = new PayInfoDTO(payInfo.Id, payInfo.UserPaid.Id, payInfo.Sum, payInfo.Currency);

			return payInfoDTO;
		}

		public CourseDTO ConvertCourse(Course course)
		{
			CourseDTO courseDTO = new CourseDTO(course.Id, course.TripId, course.CurrencyOne, course.CurrencyTwo, course.CourseAmount);

			return courseDTO;
		}
	}
}