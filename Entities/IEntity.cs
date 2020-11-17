using MongoDB.Bson;

namespace MongoHomework.Entities
{
    public interface IEntity
    {
        public ObjectId Id { get; set; }
    }
}