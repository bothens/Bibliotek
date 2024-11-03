using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Bibliotek
{
    public List<Bok> böcker = new List<Bok>();
    public List<Författare> författare = new List<Författare>();
   

    public void AddBook()
    {
        Console.Write("Ange bokens titel: ");
        string titel = Console.ReadLine();

        Console.Write("Ange författarens namn: ");
        string författareNamn = Console.ReadLine();

        Console.Write("Ange ISBN: ");
        string isbnInput = Console.ReadLine();
        int isbn;

        Console.WriteLine("Ange bokens genre");
        string genre = Console.ReadLine();

        Console.WriteLine(" Ange året boken skapades");
        string publiceringsårInput = Console.ReadLine();
        int publiceringsår;

        Console.Write("Ange Bokens Id: ");
        string IdInput = Console.ReadLine();
        int Id;

        if (string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(genre) || string.IsNullOrWhiteSpace(författareNamn) || !int.TryParse(isbnInput, out isbn) || !int.TryParse(publiceringsårInput, out publiceringsår) || !int.TryParse(IdInput, out Id))
        {
            Console.WriteLine("Ogiltig inmatning. Vänligen försök igen.");
            return;
        }

        Bok nyBok = new Bok(titel, författareNamn, genre, isbn, publiceringsår, Id);
        böcker.Add(nyBok);
        Console.WriteLine($"Boken \"{titel}\" har lagts till i biblioteket.");
     
    }

    // Metod för att lägga till en ny författare
    public void AddAuthor()
    {
        Console.Write("Ange författarens namn: ");
        string namn = Console.ReadLine();

        Console.Write("Ange författarens land: ");
        string land = Console.ReadLine();
       
        Console.Write("Ange författarens Id: ");
        string IdInput = Console.ReadLine();
        int Id;


        if (string.IsNullOrWhiteSpace(namn) || string.IsNullOrWhiteSpace(land) || !int.TryParse(IdInput, out Id))
        {
            Console.WriteLine("Ogiltig inmatning. Vänligen försök igen.");
            return;
        }

        Författare nyFörfattare = new Författare(namn, land);
        författare.Add(nyFörfattare);
        Console.WriteLine($"Författaren \"{namn}\" har lagts till i biblioteket.");
        
    }

    // Metod för att uppdatera en befintlig bok
    public void UppdateBook()
    {
        Console.Write("Ange titeln på boken som ska uppdateras: ");
        string titel = Console.ReadLine();

        var bok = böcker.FirstOrDefault(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
        if (bok == null)
        {
            Console.WriteLine("Boken hittades inte.");
            return;
        }

        Console.Write("Ange ny titel: ");
        bok.Titel = Console.ReadLine();

        Console.Write("Ange ny författare: ");
        bok.Författare = Console.ReadLine();

        Console.Write("Ange ny ISBN: ");
        if (int.TryParse(Console.ReadLine(), out int isbn))
        {
            bok.ISBN = isbn;
        }
        else
        {
            Console.WriteLine("Ogiltigt ISBN, bibehåller tidigare värde.");
        }

        Console.WriteLine($"Boken \"{bok.Titel}\" har uppdaterats.");
       
    }

    // Metod för att uppdatera en befintlig författare baserat på namn
    public void UppdateraFörfattare()
    {
        Console.Write("Ange namnet på författaren som ska uppdateras: ");
        string namn = Console.ReadLine();

        var förf = författare.FirstOrDefault(f => f.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
        if (förf == null)
        {
            Console.WriteLine("Författaren hittades inte.");
            return;
        }

        Console.Write("Ange nytt namn: ");
        förf.Namn = Console.ReadLine();

        Console.Write("Ange nytt land: ");
        förf.Land = Console.ReadLine();

        Console.WriteLine($"Författaren \"{förf.Namn}\" har uppdaterats.");
        
    }

    // Metod för att ta bort en bok baserat på titel
    public void TaBortBok()
    {
        Console.Write("Ange titeln på boken som ska tas bort: ");
        string titel = Console.ReadLine();

        var bok = böcker.FirstOrDefault(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
        if (bok != null)
        {
            böcker.Remove(bok);
            Console.WriteLine($"Boken \"{bok.Titel}\" har tagits bort.");
        }
        else
        {
            Console.WriteLine("Boken hittades inte.");
        }
      
    }

    // Metod för att ta bort en författare baserat på namn
    public void TaBortFörfattare()
    {
        Console.Write("Ange namnet på författaren som ska tas bort: ");
        string namn = Console.ReadLine();

        var förf = författare.FirstOrDefault(f => f.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
        if (förf != null)
        {
            författare.Remove(förf);
            Console.WriteLine($"Författaren \"{förf.Namn}\" har tagits bort.");
        }
        else
        {
            Console.WriteLine("Författaren hittades inte.");
        }
       
    }


// Metod för att lista alla böcker och författare
public void ListaAllaBöckerOchFörfattare()
    { 
        Console.WriteLine("Lista över alla böcker:");
        foreach (var bok in böcker)
        {
            Console.WriteLine($"- {bok.Titel} av {bok.Författare}, {bok.ISBN},{bok.Genre}, {bok.ID} {bok.Publiceringsår}");
        }

        Console.WriteLine("\nLista över alla författare:");
        foreach (var förf in författare)
        {
            Console.WriteLine($"- {förf.Namn} från {förf.Land}");
        }
        
    }

    public void SökOchFiltreraBöcker()
    {
        Console.Write("Ange sökord (titel/författare/genre): ");
        string sökord = Console.ReadLine().ToLower();

        var resultat = böcker
            .Where(bok => bok.Titel.ToLower().Contains(sökord) ||
                          bok.Författare.ToLower().Contains(sökord) ||
                          bok.Genre.ToLower().Contains(sökord))
            .ToList();

        if (!resultat.Any())
        {
            Console.WriteLine("Inga böcker hittades.");
            return;
        }

        resultat.ForEach(bok =>
            Console.WriteLine($"Titel: {bok.Titel}, Författare: {bok.Författare}, Genre: {bok.Genre}, År: {bok.Publiceringsår}")
        );
        
    }
}

