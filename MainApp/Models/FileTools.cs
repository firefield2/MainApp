using MainApp.Interfaces;
using MainApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;

namespace MainApp.Models
{
    public class FileTools
    {
        static IGridFSBucket bucket;
        public static ObjectId SaveFile(IRepository<Person> repository,FileStream stream, string fileName)
        {
            bucket = new GridFSBucket(repository.Database);
            ObjectId id = bucket.UploadFromStream(fileName,stream);
            return id;
        }

    }
}