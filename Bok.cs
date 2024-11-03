using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bok
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Författare { get; set; }
        public int ISBN { get; set; }
        public string Genre { get; set; }
        public int Publiceringsår { get; set; }
        public List<int> Betyg { get; set; } = new List<int>();

        public double GenomsnittligtBetyg => Betyg.Any() ? Betyg.Average() : 0.0;

        public Bok(string titel, string författare, string genre,int isbn,int publiceringsår, int Id)
        {
            Titel = titel;
            Författare = författare;
            ISBN = isbn;
            Genre = genre;
            Publiceringsår = publiceringsår;
            ID = Id;
        }
    }
}


