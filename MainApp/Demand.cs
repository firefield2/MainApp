using System.Collections.Generic;

namespace MainApp
{
    public  class Demand
    {
        List<string> Technologies { get; set; }
        string Availability { get; set; }
        string Price { get; set; }
        List<string> Skills { get; set; }
        string Status { get; set; }
    }
}