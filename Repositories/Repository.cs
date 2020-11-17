using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using VeterinaryClinic.Entities.Interfaces;

namespace VeterinaryClinic.Repositories
{
    public class Repository<TEntity> where TEntity : IEntity
    {
        protected readonly IMongoCollection<TEntity> Collection;

        public Repository(IMongoDatabase database)
        {
            Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public IEnumerable<TEntity> Get()
        {
            return Collection.Find(entity => true).ToList();
        }

        public TEntity Get(ObjectId id)
        {
            return Collection.Find(Builders<TEntity>.Filter.Eq(e => e.Id, id)).FirstOrDefault();
        }

        public TEntity Insert(TEntity entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        public void Replace(TEntity entity)
        {
            Collection.ReplaceOne(Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id), entity);
        }

        public void Delete(TEntity entity)
        {
            Collection.DeleteOne(e => e.Id == entity.Id);
        }
    }
}