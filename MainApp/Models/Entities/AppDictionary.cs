using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MainApp.Models.Entities
{
    public class AppDictionary : IBson
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<string> ProgramingLanguages { get; set; }
        public List<string> SkillTypes { get; set; }
        public List<string> Languages { get; set; }

    }
}