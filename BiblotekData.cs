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
       

        public List<Bok> böcker { get; set; } = new List<Bok>();
    public List<Författare> författare { get; set; } = new List<Författare>();
    }

}

