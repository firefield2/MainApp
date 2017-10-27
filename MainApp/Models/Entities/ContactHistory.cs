using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MainApp.Interfaces;

namespace MainApp.Models.Entities
{
    public class ContactHistory : IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId CandidateId { get; set; }
        public List<ContactEvent> Events { get; set; }
    }
}