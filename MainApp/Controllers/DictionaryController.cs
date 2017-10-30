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
    [RoutePrefix("api/dictionary")]
    public class DictionaryController : ApiController
    {
        IRepository<AppDictionary> repository = new Repository<AppDictionary>("Dictionary");
        // GET: api/Dictionary
        /// <summary>
        /// Pobiera słowniki z bazy danych
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public AppDictionary Get()
        {
            return repository.List().FirstOrDefault();
        }

        /// <summary>
        /// Pobiera słownik podany słownik
        /// </summary>
        /// <param name="nameOfDictionary"></param>
        /// <returns>Array of values in json</returns>
        // GET: api/Dictionary/5
        [Route("{nameOfDictionary}")]
        public List<string> Get(string nameOfDictionary)
        {
            return Dictionary.Get(repository, nameOfDictionary);
        }

        /// <summary>
        /// Pobiera słownik o podanym typie
        /// </summary>
        /// <param name="nameOfDictionary"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        // GET: api/Dictionary/5/5
        [Route("{nameOfDictionary}/{type}")]
        public List<string> Get(string nameOfDictionary , string type)
        {
            return Dictionary.Get(repository,nameOfDictionary, type);
        }

        // POST: api/Dictionary
        public void Post([FromBody]List<string> data)
        {
            Dictionary.Add(repository, data[0], data[1], data[2]);
        }
    }
}
