using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Models.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainApp.Controllers
{
    public class PersonController : ApiController
    {
        IRepository<Person> repository = new Repository<Person>("persons");
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return repository.List();
        }

        // GET: api/Person/5
        public Person Get(string id)
        {
            return repository.FindById(new ObjectId(id));
        }

        // POST: api/Person
        public void Post([FromBody]Person value)
        {
            repository.Add(value);
        }

        // POSt: api/Person/5
        public void Post(string id, [FromBody]Person value)
        {
            value.Id = new ObjectId(id);
            repository.Update(value);
        }

        // DELETE: api/Person/5
        public void Delete(String id)
        {
            repository.Delete(new ObjectId(id));
        }
    }
}
