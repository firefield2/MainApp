using MainApp.Interfaces;
using MainApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace MainApp.Models
{
    public static class FileTools
    {
        static IGridFSBucket bucket;
        public static ObjectId SaveFile(IRepository<Person> repository, Stream stream, string fileName)
        {
            bucket = new GridFSBucket(repository.Database);
            ObjectId id = bucket.UploadFromStream(fileName, stream);
            return id;
        }

        public static byte[] GetFile(IRepository<Person> repository, ObjectId id)
        {
            bucket = new GridFSBucket(repository.Database);
            //bucket.DownloadToStream(id, stream);
            var bytes = bucket.DownloadAsBytes(id);
            return bytes;
        }
        public static void DeleteFile(IRepository<Person> repository, ObjectId id)
        {
            bucket = new GridFSBucket(repository.Database);
            bucket.Delete(id);
        }
        public static void AddFileInfoToPerson(IRepository<Person> repository, string personId, Entities.File file)
        {
            var builder = Builders<Person>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(personId));
            var update = Builders<Person>.Update.Push("Files", file);
            //var searchQuery = String.Format(@"{{_id : ");
            //var updateQuery = String.Format(@"");
            repository.GetCollection().UpdateOne(filter, update);
        }

    }
}