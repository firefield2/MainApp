using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MainApp.Controllers
{
    public class FileController : ApiController
    {
        IRepository<Company> repository = new Repository<Company>("companies");
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
        public async Task<HttpResponseMessage> Post(File file)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            try
            {
                var filedata = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
                foreach (var fileItem in filedata.Contents)
                {
                    var fileStream = await fileItem.ReadAsStreamAsync();
                    
                    FileTools.SaveFile(repository)
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
