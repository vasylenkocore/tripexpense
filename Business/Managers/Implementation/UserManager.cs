using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class UserManager : BaseManager
	{
		public void AddOrUpdate(User user)
		{
			UserDTO userDTO = EntityConverter.ConvertUser(user);

			DataAccessClient.AddOrUpdate(userDTO);
		}
	}
}