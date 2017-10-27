using MainApp.Interfaces;
using MainApp.Models.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp.Models
{
    public class Dictionary
    {
        public static List<string> Get (IRepository<AppDictionary> repository, string dictionary, string type = null)
        {
            List<string> toReturn = new List<string>();
            switch (dictionary)
            {
                case "Skills":
                    toReturn = repository.List().FirstOrDefault().Skills.FindAll(x => x.Type == type).Select(x => x.Name).ToList();
                    break;
                case "SkillTypes":
                    toReturn = repository.List().FirstOrDefault().SkillTypes;
                    break;
                default:
                    break;
            }
            return toReturn;
        }
        public static void Add(IRepository<AppDictionary> repository, string dictionary, string value, string type)
        {
            if (!string.IsNullOrEmpty(type)) value = "[" + type + ", " + value + "]";
            var str = @"{ $addToSet: { """+ dictionary+@"""  :  """ +value+ @""" }";
            var result = repository.GetCollection().UpdateOne("{}", str);
        }
    }
}