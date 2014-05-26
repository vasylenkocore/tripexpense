using DataAccess.Entities.Interfaces;

namespace DataAccess
{
	public interface IDataAccessClient
	{
		void AddOrUpdate<T>(T entity) where T : IIdentityObject;

		void Delete<T>(string id) where T : IIdentityObject;

		T Get<T>(string id) where T : IIdentityObject;
	}
}