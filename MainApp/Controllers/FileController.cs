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
using System.Web;
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
        public async Task<string> Post()
        {
            string fileId = "";
            string root = HttpContext.Current.Server.MapPath("~/App_Data/tempFiles/");
            try
            {

                var provider = new MultipartFormDataStreamProvider(root);
                var filedata = await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var fileItem in provider.FileData)
                {
                    FileStream stream = System.IO.File.Open(fileItem.LocalFileName, FileMode.Open);
                    var fileName= fileItem.Headers.ContentDisposition.FileName;
                    fileName=  fileName.Trim().Substring(1, fileName.Length - 2);
                    fileId = FileTools.SaveFile(repository, stream, fileName).ToString();
                    System.IO.File.SetAttributes(fileItem.LocalFileName, FileAttributes.Normal);
                    if (stream != null)
                    {
                        stream.Dispose();
                    }
                    System.IO.File.Delete(fileItem.LocalFileName);
                }
            }
            catch (IOException ex)
            {
                var text = ex.Message;
            }
            return fileId;
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
