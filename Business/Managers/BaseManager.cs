using Business.Converters;
using DataAccess;

namespace Business.Managers
{
	public abstract class BaseManager
	{
		protected readonly IDataAccessClient DataAccessClient;

		protected readonly IEntityConverter EntityConverter;

		protected BaseManager()
		{
			DataAccessClient = new DataAccessClient();
			EntityConverter = new EntityConverter();
		}
	}
}