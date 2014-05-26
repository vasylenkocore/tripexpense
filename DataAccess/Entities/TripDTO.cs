using System;
using System.Collections.Generic;
using DataAccess.Entities.Interfaces;
using DataAccess.Helper;

namespace DataAccess.Entities
{
	public class TripDTO : IIdentityObject
	{
		public TripDTO(string name, string description)
			: this(MongoIdentityHelper.GetSimpleIdentity(name), name, description, new List<string>(), new List<ExpenseDTO>())
		{
		}

		public TripDTO(string id, string name, string description, List<string> userIds, List<ExpenseDTO> expenses)
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

			if (userIds == null)
			{
				throw new ArgumentNullException("userIds");
			}

			if (expenses == null)
			{
				throw new ArgumentNullException("expenses");
			}

			Id = id;
			Name = name;
			Description = description;
			UserIds = userIds;
			ExpenseDTOs = expenses;
		}

		public string Description { get; set; }

		public string Name { get; set; }

		public List<string> UserIds { get; set; }

		public List<ExpenseDTO> ExpenseDTOs { get; set; }

		public string Id { get; set; }
	}
}