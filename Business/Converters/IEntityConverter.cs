using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Converters
{
	public interface IEntityConverter
	{
		UserDTO Convert(User user);

		TripDTO Convert(Trip trip);

		ExpenseDTO Convert(Expense expense);

		PayInfoDTO Convert(PayInfo payInfo);

		RateDTO Convert(Rate rate, string tripId);

		Rate Convert(RateDTO rateDTO);

		Trip Convert(TripDTO trip);
	}
}