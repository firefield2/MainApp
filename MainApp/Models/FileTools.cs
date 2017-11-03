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

    }
}