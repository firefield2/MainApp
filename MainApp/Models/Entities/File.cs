﻿using MongoDB.Bson;

namespace MainApp.Models.Entities
{
    public class File
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
}