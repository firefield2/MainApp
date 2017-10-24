using System.Collections.Generic;

namespace MainApp.Models
{
    public class WantedPerson
    {
        public string Price { get; set; }
        public string Availability { get; set; }
        public List<Skill> Skills { get; set; }
        public string Status { get; set; }
    }
}