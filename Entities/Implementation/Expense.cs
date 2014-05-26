using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entities.Implementation
{
	[DataContract]
	public class Expense : IEntity
	{
		public Expense(string id, string name, string description, List<PayInfo> paidInfo)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			if (description == null)
			{
				throw new ArgumentNullException("description");
			}

			if (paidInfo == null)
			{
				throw new ArgumentNullException("paidInfo");
			}

			Id = id;
			Name = name;
			Description = description;
			PaidInfo = paidInfo;
		}

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public List<PayInfo> PaidInfo { get; set; }

		[DataMember]
		public string Name { get; set; }
	}
}