using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MainApp.Models.Entities
{
    public class AppDictionary : IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<string> Skills { get; set; }

    }
}