using MongoDB.Bson;

namespace MainApp.Models
{
    public class Cv
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObjectId FileId { get; set; }
    }
}