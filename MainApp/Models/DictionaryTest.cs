using MainApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainApp.Models
{
    public class DictionaryTest
    {
        public static string Add(Repository<AppDictionary> repo, string mainVal, string optionalVal = null)
        {
            string text = string.Format(@"{{$addToSet:{{""{0}"":""{1}""}}}}", mainVal, optionalVal);
            repo.GetCollection("Dictionary").UpdateOne("{}",text);
            return text;
        }
    }
}