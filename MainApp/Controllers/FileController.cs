using MainApp.Interfaces;
using MainApp.Models;
using MainApp.Models.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MainApp.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        IRepository<Person> repository = new Repository<Person>("persons");

        [Route("{personId}")]
        // GET: api/File
        public IEnumerable<Models.Entities.File> Get(string personId)
        {
            Person person = repository.FindById(new ObjectId(personId));
            return person.Files;
        }

        // GET: api/File/5
        [Route("{personId}/{fileId}")]
        public HttpResponseMessage Get(string personId, string fileId)
        {
            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/tempFiles/");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new System.IO.MemoryStream();
            var fileBytes  =  FileTools.GetFile(repository, new ObjectId(fileId));
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(root);
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            Person person = repository.FindById(new ObjectId(personId));
            var files = person.Files.Find(x=> x.FileId==fileId);
            using (Stream file = System.IO.File.Create(root+files.Name, (int)fileBytes.Length))
            {
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(fileBytes, 0, fileBytes.Length);
                file.Write(fileBytes, 0, fileBytes.Length);
            }
            response.Content = new StreamContent(new FileStream(root+files.Name, FileMode.Open,FileAccess.Read));
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = fileBytes.Length;
            response.Content.Headers.ContentDisposition.FileName = files.Name;
            response.Content.Headers.ContentDisposition.Size = fileBytes.Length;
            return response;
            
        }

        [Route("{personId}")]
        // POST: api/File
        public void Post(string personId, [FromBody]Models.Entities.File file)
        {
            FileTools.AddFileInfoToPerson(repository, personId, file);

        }

        // POST: api/File
        public async Task<string> Post()
        {
            string fileId = "";
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                //HttpContent content =  provider.Contents.Select(x=> )
                foreach (var fileItem in provider.Contents)
                {
                    var fileName = fileItem.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await fileItem.ReadAsStreamAsync();
                    fileId = FileTools.SaveFile(repository, buffer, fileName).ToString();
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
        [Route("{id}")]
        // DELETE: api/File/5
        public void Delete(string id)
        {
            FileTools.DeleteFile(repository,new ObjectId(id));
        }
    }
}
