using MainApp.Interfaces;
using MainApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp.Models
{
    public class Repository<T> : IRepository<T> where T : IBson
    {
        IMongoCollection<T> collection;
        IMongoClient client;
        IMongoDatabase database;
        public Repository(string collectionName)
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("MainApp");
            //database.DropCollection(collectionName);
            GetCollection(collectionName);

        }

        public IEnumerable<T> List()
        {
            
            return collection.Find(new BsonDocument()).ToEnumerable();
        }

        public IMongoCollection<T> GetCollection(string collectionName)
        {
            return collection = database.GetCollection<T>(collectionName);
        }

        public T FindById(ObjectId id)
        {
            return collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Add(T element)
        {
            collection.InsertOne(element);
        }

        public void Update(T element)
        {
            collection.ReplaceOne(x => x.Id == element.Id, element);
        }
        public void Delete(ObjectId id)
        {
            collection.DeleteOne(x => x.Id == id);
        }
    }
}