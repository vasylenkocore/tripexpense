using DataAccess.Entities;
using Entities.Implementation;

namespace Business.Managers.Implementation
{
	public class PayInfoManager : BaseManager
	{
		public void AddOrUpdate(PayInfo payInfo, string expenseId)
		{
			PayInfoDTO payInfoDTO = EntityConverter.Convert(payInfo);

			DataAccessClient.AddOrUpdate(payInfoDTO);
		}
	}
}