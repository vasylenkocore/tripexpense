using System;
using DataAccess.Entities.Interfaces;
using DataAccess.Helper;

namespace DataAccess.Entities
{
	public class PayInfoDTO : IIdentityObject
	{
		public PayInfoDTO(string userPaidId, double sum, string currency)
			: this(MongoIdentityHelper.GetRandomId(), userPaidId, sum, currency)
		{
		}

		public PayInfoDTO(string id, string userPaidId, double sum, string currency)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (userPaidId == null)
			{
				throw new ArgumentNullException("userPaidId");
			}

			if (currency == null)
			{
				throw new ArgumentNullException("currency");
			}

			Id = id;
			UserPaidId = userPaidId;
			Sum = sum;
			Currency = currency;
		}

		public string Id { get; set; }

		public double Sum { get; set; }

		public string Currency { get; set; }

		public string UserPaidId { get; set; }
	}
}