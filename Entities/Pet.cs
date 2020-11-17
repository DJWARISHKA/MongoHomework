using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoHomework.Entities
{
    public class Pet : IEntity
    {
        public string Name { get; set; }
        public PetKind Kind { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        public Owner Owner { get; set; }

        [BsonId] [BsonIgnoreIfDefault] public ObjectId Id { get; set; }
    }

    public enum PetKind
    {
        Кот,
        Собака,
        Птица
    }
}