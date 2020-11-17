using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using VeterinaryClinic.Entities;

namespace VeterinaryClinic.Repositories
{
    public class Pets : Repository<Pet>
    {
        public Pets(IMongoDatabase database) : base(database)
        {
            Collection.Indexes.CreateMany(new[]
            {
                new CreateIndexModel<Pet>(Builders<Pet>.IndexKeys.Descending(pet => pet.Date)),
                new CreateIndexModel<Pet>("{Type:1}")
            });
        }

        public long Count()
        {
            return Collection.EstimatedDocumentCount();
        }

        public IEnumerable<Pet> Search(int pageNumber, int pageSize = 3)
        {
            return Collection.Find(pet => true)
                .Sort(Builders<Pet>.Sort.Descending(pet => pet.Date))
                .Skip(pageNumber * pageSize)
                .Limit(pageSize).ToList();
        }

        public List<Group> GetReport()
        {
            return Collection
                .Aggregate(new AggregateOptions {AllowDiskUse = true})
                .Group(p => p.Type, group => new Group(group.Key, group.Count()))
                .ToList();
        }
    }

    public class Group
    {
        public readonly PetTypes Key;
        public readonly int Count;

        public Group(PetTypes key, int count)
        {
            Key = key;
            Count = count;
        }
    }
}