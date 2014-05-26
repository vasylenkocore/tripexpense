using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities.Interfaces
{
	public interface IIdentityObject
	{
		[BsonId]
		string Id { get; set; }
	}
}