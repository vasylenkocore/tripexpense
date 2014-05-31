using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class UserManager : BaseManager
	{
		public void AddOrUpdate(User user)
		{
			UserDTO userDTO = EntityConverter.Convert(user);

			DataAccessClient.AddOrUpdate(userDTO);
		}
	}
}