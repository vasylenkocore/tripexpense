using System;
using DataAccess.Entities.Interfaces;
using DataAccess.Helper;

namespace DataAccess.Entities
{
	public class UserDTO : IIdentityObject
	{
		public UserDTO(string name, string password, string phoneNumber, string email)
			: this(MongoIdentityHelper.GetSimpleIdentity(phoneNumber), name, password, phoneNumber, email)
		{
		}

		public UserDTO(string id, string name, string password, string phoneNumber, string email)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}

			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			if (password == null)
			{
				throw new ArgumentNullException("password");
			}

			if (phoneNumber == null)
			{
				throw new ArgumentNullException("phoneNumber");
			}

			Id = id;
			Name = name;
			Password = password;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public string Id { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }
	}
}