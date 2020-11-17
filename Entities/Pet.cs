using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VeterinaryClinic.Entities.Interfaces;

namespace VeterinaryClinic.Entities
{
    public class Pet : IEntity
    {
        public string Name { get; set; }
        public PetTypes Type { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        public Owner Owner { get; set; }

        [BsonId] [BsonIgnoreIfDefault] public ObjectId Id { get; set; }
    }

    public enum PetTypes
    {
        Cat,
        Dog,
        Bird
    }
}