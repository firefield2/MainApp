using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MainApp.Interfaces
{
    public interface IRepository<T> where T : IBson
    {
        IMongoDatabase Database { get;}
        void Add(T element);
        void Delete(ObjectId id);
        T FindById(ObjectId id);
        IEnumerable<T> List();
        void Update(T element);
        IMongoCollection<T> GetCollection();
    }
}