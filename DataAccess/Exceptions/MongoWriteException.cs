using System;

namespace DataAccess.Exceptions
{
	public class MongoWriteException : Exception
	{
		public MongoWriteException(string message)
			: base(message)
		{
		}
	}
}