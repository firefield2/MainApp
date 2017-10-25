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
        public enum State
        {
            Opened,
            Closed,
            TimeOut
        }
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId CompanyId { get; set; }

        public int NeededPersons { get; set; }

        public int StillNeededPersons { get; set; }
        public int Salary { get; set; }
        public int AvailabilityInDays { get; set; }
        public List<Skill> Skills { get; set; }
        public State ContractState{ get; set; }
    }
}