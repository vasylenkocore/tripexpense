using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entities.Implementation
{
	[DataContract]
	public class Trip : IEntity
	{
		public Trip(string id, string name, string description, List<User> users, List<Expense> expenses) :
			this(id, name, description)
		{
			if (users == null)
			{
				throw new ArgumentNullException("users");
			}
			
			if (expenses == null)
			{
				throw new ArgumentNullException("expenses");
			}
			
			Users = users;
			Expenses = expenses;
		}

		public Trip(string id, string name, string description)
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

			Id = id;
			Name = name;
			Description = description;
			Users = new List<User>();
			Expenses = new List<Expense>();
		}

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public List<User> Users { get; set; }

		[DataMember]
		public List<Expense> Expenses { get; set; }
	}
}