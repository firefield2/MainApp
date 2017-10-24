using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp.Models
{
    public class Company : IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<ObjectId> Contracts { get; set; }
    }
}