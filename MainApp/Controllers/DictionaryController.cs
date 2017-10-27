using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainApp.Controllers
{
    public class DictionaryController : ApiController
    {
        IRepository<AppDictionary> repository = new Repository<AppDictionary>("Dictionary");
        // GET: api/Dictionary
        public IEnumerable<AppDictionary> Get()
        {
            return repository.List();
        }

        // GET: api/Dictionary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dictionary
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Dictionary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dictionary/5
        public void Delete(int id)
        {
        }
    }
}
