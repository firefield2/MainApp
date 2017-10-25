using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MainApp.Models.Entities
{
    public class Company : IBson
    {
        string zipCode;
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                if (Regex.IsMatch(value, @"\d{2}-\d{3}"))
                {
                    zipCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format(value+" nie jest prawidłowym kodem pocztowym!"));
                }
            }
        }
        public List<Contact> Contacts { get; set; }

    }
}