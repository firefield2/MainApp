using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MainApp.Models
{
    public class ContactHistory : IBson
    {//TODO odniesienia do kontraktów i osób + historia-co i kiedy
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId PersonId { get; set; }
        public ObjectId ContractId { get; set; }
        public List<ContactEvent> Events { get; set; }
    }
}