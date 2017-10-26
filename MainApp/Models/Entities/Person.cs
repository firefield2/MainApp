using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp.Models.Entities
{
    public class Person : IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetAndNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int AvailabilityInDays { get; set; }
        public int ExpectedSalary { get; set; }
        public List<Skill> Skills { get; set; }
        public List<WorkExpirience> Expirience { get; set; }
        public List<File> Files { get; set; }
    }
}