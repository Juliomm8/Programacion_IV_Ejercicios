using System.Collections.Generic;

namespace StarWarsApiWebApp.Models
{
    public class StarWarsResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Personaje> results { get; set; }
    }
}