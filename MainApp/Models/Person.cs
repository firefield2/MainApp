using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp.Models
{
    public class Person : IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Availability { get; set; }
        public string Price { get; set; }
        public List<Skill> Skills { get; set; }
        public List<string> Expirience { get; set; }
        public List<Cv> Files { get; set; }
    }
}