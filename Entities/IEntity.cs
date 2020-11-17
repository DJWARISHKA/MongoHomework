using MongoDB.Bson;

namespace VeterinaryClinic.Entities.Interfaces
{
    public interface IEntity
    {
        public ObjectId Id { get; set; }
    }
}
