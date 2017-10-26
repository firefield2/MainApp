using System;

namespace MainApp.Models.Entities
{
    public class Education
    {
        public string NameOfInstitution { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime StartEducation { get; set; }
        public DateTime EndEducation { get; set; }
    }
}