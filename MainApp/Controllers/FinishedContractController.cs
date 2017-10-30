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
    public class FinishedContractController : ApiController
    {
        IRepository<FinishedContract> repository = new Repository<FinishedContract>("companies");
        // GET: api/FinishedContract
        public IEnumerable<FinishedContract> Get()
        {
            return repository.List();
        }

        // GET: api/FinishedContract/5
        public FinishedContract Get(string id)
        {
            return repository.FindById(new ObjectId(id));
        }

        // POST: api/FinishedContract
        public void Post([FromBody]FinishedContract value)
        {
            repository.Add(value);
        }

        // POST: api/FinishedContract
        public void Post(string id, [FromBody]FinishedContract value)
        {
            value.Id = new ObjectId(id);
            repository.Update(value);
        }

        // DELETE: api/FinishedContract/5
        public void Delete(string id)
        {
            repository.Delete(new ObjectId(id));
        }


}
