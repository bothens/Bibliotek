using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BibliotekData
    {
       [JsonPropertyName("böcker")]
        public List<Bok> Böcker { get; set; }
       

        [JsonPropertyName("författare")]
        public List<Författare> Författare { get; set; }
    }

}

