using MongoDB.Driver;

namespace DataAccess.Builders
{
	public class MongoServerBuilder
	{
		public MongoServer Build()
		{
			const string ConnectionString = "mongodb://localhost";
			MongoClient client = new MongoClient(ConnectionString);
	
			return client.GetServer();
		}
	}
}