using System;

namespace DataAccess.Helper
{
	public static class MongoIdentityHelper
	{
		public static string GetSimpleIdentity(string param)
		{
			return param.ToSafeBase64();
		}

		public static string GetRandomId()
		{
			return Guid.NewGuid().ToString();
		}

		public static string GetComplexIdentity(params string[] parameters)
		{
			return string.Join("|", parameters).ToSha512();
		}
	}
}