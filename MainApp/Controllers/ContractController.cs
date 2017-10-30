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
    public class ContractController : ApiController
    {
        IRepository<Contract> repository = new Repository<Contract>("contracts");
        // GET: api/Contract
        public IEnumerable<Contract> Get()
        {
            return repository.List();
        }

        // GET: api/Contract/5
        public Contract Get(string id)
        {
            return repository.FindById(new ObjectId(id));
        }

        // POST: api/Contract
        public void Post([FromBody]Contract value)
        {
            repository.Add(value);
        }

        // POST: api/Contract
        public void Post(string id, [FromBody]Contract value)
        {
            value.Id = new ObjectId(id);
            repository.Update(value);
        }

        // DELETE: api/Contract/5
        public void Delete(string id)
        {
            repository.Delete(new ObjectId(id));
        }
    }
}
