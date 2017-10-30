using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MainApp.Controllers
{
    public class FileController : ApiController
    {
        IRepository<Person> repository = new Repository<Person>("persons");
        // GET: api/File
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/File/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/File
        public async Task<HttpResponseMessage> Post(Models.Entities.File file)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            try
            {
                var filedata = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
                foreach (var fileItem in filedata.Contents)
                {
                    var fileStream = await fileItem.ReadAsStreamAsync();

                    file.FileId = FileTools.SaveFile(repository, fileStream as FileStream, file.Name);
                }

                response = Request.CreateResponse<bool>(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse<bool>(HttpStatusCode.InternalServerError, false);
            }
            return response;
        }

        // PUT: api/File/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/File/5
        public void Delete(int id)
        {
        }
    }
}
