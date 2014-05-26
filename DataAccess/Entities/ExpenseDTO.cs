using System;
using System.Collections.Generic;

using DataAccess.Entities.Interfaces;
using DataAccess.Helper;

namespace DataAccess.Entities
{
	public class ExpenseDTO : IIdentityObject
	{
		public ExpenseDTO(string name, string description, List<PayInfoDTO> paidInfo)
			: this(MongoIdentityHelper.GetRandomId(), name, description, paidInfo)
		{
		}

		public ExpenseDTO(string id, string name, string description, List<PayInfoDTO> paidInfo)
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

			Id = MongoIdentityHelper.GetRandomId();
			Name = name;
			Description = description;
			PaidInfo = paidInfo;
		}

		public string Id { get; set; }

		public string Description { get; set; }

		public List<PayInfoDTO> PaidInfo { get; set; }

		public string Name { get; set; }
	}
}