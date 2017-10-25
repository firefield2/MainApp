using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MainApp.Models.Entities
{
    public class FinishedContract : IBson

    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId CompanyId { get; set; }
        public ObjectId PersonId { get; set; }
        public int Salary { get; set; }

        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
    }
}