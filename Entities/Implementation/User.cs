using System;
using System.Runtime.Serialization;

namespace Entities.Implementation
{
	[DataContract]
	public class User : IEntity
	{
		public User(string id, string name, string password, string phoneNumber, string email)
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

		[DataMember]
		public string Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Password { get; set; }

		[DataMember]
		public string PhoneNumber { get; set; }

		[DataMember]
		public string Email { get; set; }
	}
}