using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Converters
{
	internal class EntityConverter : IEntityConverter
	{
		private readonly IDataAccessClient dataAccessClient;

		public EntityConverter(IDataAccessClient dataAccessClient)
		{
			this.dataAccessClient = dataAccessClient;
		}

		public UserDTO Convert(User user)
		{
			UserDTO userDTO = new UserDTO(user.Id, user.Name, user.Password, user.PhoneNumber, user.Email);
			return userDTO;
		}

		public TripDTO Convert(Trip trip)
		{
			List<string> userIds = trip.Users.Select(user => user.Id).ToList();
			List<ExpenseDTO> expenses = trip.Expenses.Select(Convert).ToList();

			TripDTO tripDTO = new TripDTO(trip.Id, trip.Name, trip.Description, userIds, expenses);

			return tripDTO;
		}

		public ExpenseDTO Convert(Expense expense)
		{
			List<PayInfoDTO> payments = expense.PaidInfo.Select(Convert).ToList();

			ExpenseDTO expenseDTO = new ExpenseDTO(expense.Id, expense.Name, expense.Description, payments);

			return expenseDTO;
		}

		public PayInfoDTO Convert(PayInfo payInfo)
		{
			PayInfoDTO payInfoDTO = new PayInfoDTO(payInfo.Id, payInfo.UserPaid.Id, payInfo.Sum, payInfo.Currency);

			return payInfoDTO;
		}

		public RateDTO Convert(Rate rate, string tripId)
		{
			RateDTO rateDTO = new RateDTO(
				tripId,
				rate.CurrencyOne,
				rate.CurrencyTwo,
				rate.RateAmount);

			return rateDTO;
		}

		public Rate Convert(RateDTO rateDTO)
		{
			Rate rate = new Rate(
				rateDTO.Id,
				rateDTO.TripId,
				rateDTO.CurrencyOne,
				rateDTO.CurrencyTwo,
				rateDTO.Course);

			return rate;
		}

		public Trip Convert(TripDTO tripDTO)
		{
			Trip trip = new Trip(tripDTO.Id, tripDTO.Name, tripDTO.Description);

			foreach (string userId in tripDTO.UserIds)
			{
				UserDTO userDTO = dataAccessClient.Get<UserDTO>(userId);

				if (userDTO != null)
				{
					User user = Convert(userDTO);
					trip.Users.Add(user);
				}
			}

			foreach (ExpenseDTO expenseDTO in tripDTO.ExpenseDTOs)
			{
				trip.Expenses.Add(Convert(expenseDTO));
			}

			return trip;
		}

		private Expense Convert(ExpenseDTO expenseDTO)
		{
			List<PayInfo> payments = expenseDTO.PaidInfo.Select(Convert).ToList();

			Expense expense = new Expense(expenseDTO.Id, expenseDTO.Name, expenseDTO.Description, payments);

			return expense;
		}

		private PayInfo Convert(PayInfoDTO payInfoDTO)
		{
			UserDTO userDTO = dataAccessClient.Get<UserDTO>(payInfoDTO.UserPaidId);
			User user = Convert(userDTO);

			PayInfo payInfo = new PayInfo(payInfoDTO.Id, user, payInfoDTO.Sum, payInfoDTO.Currency);

			return payInfo;
		}

		private User Convert(UserDTO userDTO)
		{
			User user = new User(userDTO.Id, userDTO.Name, userDTO.Password, userDTO.PhoneNumber, userDTO.Email);
			return user;
		}
	}
}