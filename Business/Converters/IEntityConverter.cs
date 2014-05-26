using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Converters
{
	public interface IEntityConverter
	{
		UserDTO ConvertUser(User user);

		TripDTO ConvertTrip(Trip trip);

		ExpenseDTO ConvertExpense(Expense expense);

		PayInfoDTO ConvertPayInfo(PayInfo payInfo);

		CourseDTO ConvertCourse(Course course);
	}
}