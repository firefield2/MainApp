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
    public class CompanyController : ApiController
    {
        IRepository<Company> repository = new Repository<Company>("companies");
        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            return repository.List();
        }

        // GET: api/Company/5
        public Company Get(string id)
        {
            return repository.FindById(new ObjectId(id));
        }

        // POST: api/Company
        public void Post([FromBody]Company value)
        {
            repository.Add(value);
        }
        // POST: api/Company
        public void Post(string id,[FromBody]Company value)
        {
            value.Id = new ObjectId(id);
            repository.Update(value);
        }

        // PUT: api/Company/5
        public void Put(String id, [FromBody]Company value)
        {
            
        }

        // DELETE: api/Company/5
        public void Delete(string id)
        {
            repository.Delete(new ObjectId(id));
        }
    }
}
