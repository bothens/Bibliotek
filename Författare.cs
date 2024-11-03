using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Författare
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Land { get; set; }

        public Författare(string namn, string land)
        {
            Namn = namn;
            Land = land;
        }
    }



}
   

