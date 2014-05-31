using System;
using System.Collections.Generic;

using DataAccess;
using DataAccess.Entities;
using DataAccess.Entities.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.DataAccess
{
	[TestClass]
	public class DataAccessClientTest
	{
		[TestMethod]
		public void UserDTOSaveSaveLoadDeleteTest()
		{		
			UserDTO user = new UserDTO("Test", "123456", "+380501111111", "test@test.com");
			SaveSaveLoadDeleteTest<UserDTO>(user);
		}

		public void FillTrip(Action<TripDTO> action)
		{
			IDataAccessClient dataAccessClient = new DataAccessClient();

			TripDTO tripDTO = new TripDTO(Guid.NewGuid().ToString(), "Yo-ho-ho, it's my first trip");

			UserDTO antonUser = new UserDTO("Anton", "123456", Guid.NewGuid().ToString(), "Anton@test.com");
			UserDTO nataliaUser = new UserDTO("Natalia", "123456", Guid.NewGuid().ToString(), "Natalia@test.com");
			UserDTO sergeyUser = new UserDTO("Sergey", "123456", Guid.NewGuid().ToString(), "Sergey@test.com");
			UserDTO illiaUser = new UserDTO("Illia", "123456", Guid.NewGuid().ToString(), "Illia@test.com");

			RateDTO rateDTO1 = new RateDTO(tripDTO.Id, "UAH", "USD", 11.98);
			RateDTO rateDTO2 = new RateDTO(tripDTO.Id, "UAH", "EUR", 16.55);

			try
			{
				dataAccessClient.AddOrUpdate(antonUser);
				dataAccessClient.AddOrUpdate(nataliaUser);
				dataAccessClient.AddOrUpdate(sergeyUser);
				dataAccessClient.AddOrUpdate(illiaUser);

				dataAccessClient.AddOrUpdate(rateDTO1);
				dataAccessClient.AddOrUpdate(rateDTO2);

				tripDTO.UserIds.Add(antonUser.Id);
				tripDTO.UserIds.Add(nataliaUser.Id);
				tripDTO.UserIds.Add(sergeyUser.Id);
				tripDTO.UserIds.Add(illiaUser.Id);

				List<PayInfoDTO> paidInfoFly =
					new List<PayInfoDTO>
					    {
						    new PayInfoDTO(nataliaUser.Id, 602.56, "USD"),
						    new PayInfoDTO(antonUser.Id, 155.62, "UAH")
					    };

				tripDTO.ExpenseDTOs.Add(new ExpenseDTO("Fly", "Kiev-Amsterdam", paidInfoFly));

				List<PayInfoDTO> paidInfoTrain =
					new List<PayInfoDTO>
						{
							new PayInfoDTO(illiaUser.Id, 1200.21, "UAH")
						};

				tripDTO.ExpenseDTOs.Add(new ExpenseDTO("Train", "Dnepr-Kiev", paidInfoTrain));

				dataAccessClient.AddOrUpdate(tripDTO);
			}
			finally
			{
				action(tripDTO);

				dataAccessClient.Delete<UserDTO>(antonUser.Id);
				dataAccessClient.Delete<UserDTO>(nataliaUser.Id);
				dataAccessClient.Delete<UserDTO>(sergeyUser.Id);
				dataAccessClient.Delete<UserDTO>(illiaUser.Id);

				dataAccessClient.Delete<RateDTO>(rateDTO1.Id);
				dataAccessClient.Delete<RateDTO>(rateDTO2.Id);

				dataAccessClient.Delete<TripDTO>(tripDTO.Id);
			}
		}

		[TestMethod]
		public void TripDTOSaveDeleteTest()
		{
			FillTrip(trip => { });
		}

		private void SaveSaveLoadDeleteTest<T>(IIdentityObject identityObject) where T : IIdentityObject
		{
			IDataAccessClient dataAccessClient = new DataAccessClient();

			dataAccessClient.AddOrUpdate(identityObject);
			dataAccessClient.AddOrUpdate(identityObject);

			T dtoFromDatabase = dataAccessClient.Get<T>(identityObject.Id);

			Assert.IsNotNull(dtoFromDatabase);

			dataAccessClient.Delete<T>(dtoFromDatabase.Id);

			T dto = dataAccessClient.Get<T>(identityObject.Id);

			Assert.IsNull(dto);
		}
	}
}