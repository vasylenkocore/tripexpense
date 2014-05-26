using System;
using System.Runtime.Serialization;

namespace Entities.Implementation
{
	[DataContract]
	public class PayInfo : IEntity
	{
		public PayInfo(string id, User userPaid, double sum, string currency)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (userPaid == null)
			{
				throw new ArgumentNullException("userPaid");
			}

			if (currency == null)
			{
				throw new ArgumentNullException("currency");
			}

			Id = id;
			UserPaid = userPaid;
			Sum = sum;
			Currency = currency;
		}

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public double Sum { get; set; }

		[DataMember]
		public string Currency { get; set; }

		[DataMember]
		public User UserPaid { get; set; }
	}
}