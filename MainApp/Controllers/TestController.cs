using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainApp.Controllers
{
    public class TestController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            switch (id)
            {
                case 1:
                    Repository<Person> database1 = new Repository<Person>("candidates");
                    database1.Add(new Person() { Adress = "test", Availability = "test", FirstName = "test", LastName = "test", Price = "test", Skills = new List<Skill>() { new Skill() { Level = "test", Name = "JS" } }, Expirience = new List<string>() { "test1", "test2" }, Cv = new List<string>() { "test1", "test2" } });
                    break;
                case 2:
                    Repository<Company> database2 = new Repository<Company>("companies");
                    database2.Add(new Company() { Contracts = new List<MongoDB.Bson.ObjectId>() { new MongoDB.Bson.ObjectId(), new MongoDB.Bson.ObjectId()},Contacts = new List<Contact>() { new Contact() { Name = "test", Number="test" } } });
                    break;
                default:
                    break;
            }
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}