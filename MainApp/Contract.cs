using MainApp.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp
{
    public class Contract: IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        List<Demand> Persons { get; set; }
        string ContractStatus { get; set; }

    }
}