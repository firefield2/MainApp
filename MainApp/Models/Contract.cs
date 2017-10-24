using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace MainApp.Models
{
    public class Contract :IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<WantedPerson> WantedPersons { get; set; }
        public string ContractStatus{ get; set; }
    }
}