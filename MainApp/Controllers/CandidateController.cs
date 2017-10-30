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
    public class CandidateController : ApiController
    {
        IRepository<Candidate> repository = new Repository<Candidate>("candidates");
        // GET: api/Candidate
        public IEnumerable<Candidate> Get()
        {
            return repository.List();
        }

        // GET: api/Candidate/5
        public Candidate Get(string id)
        {
            return repository.FindById(new ObjectId(id));
        }

        // POST: api/Candidate
        public void Post([FromBody]Candidate value)
        {
            repository.Add(value);
        }

        // Post: api/Candidate/5
        public void Post(string id, [FromBody]Candidate value)
        {
            value.Id = new ObjectId(id);
            repository.Update(value);
        }


        // DELETE: api/Candidate/5
        public void Delete(string id)
        {
            repository.Delete(new ObjectId(id));
        }
    }
}
