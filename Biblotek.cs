using ConsoleApp1;
using System.Text.Json;
public class Bibliotek
{







    public readonly string dataFilPath = "LibraryData.json";
    public BibliotekData BibliotekData { get; set; }
    public void LaddaData()
    {
        if (File.Exists(dataFilPath))
        {
            string jsonData = File.ReadAllText(dataFilPath);
            BibliotekData = JsonSerializer.Deserialize<BibliotekData>(jsonData)!;
        }
        else
        {
            Console.WriteLine("Ingen JSON-fil hittades, börjar med tomt bibliotek.");
        }
    }

    public void SparaData()
    {
        string jsonData = JsonSerializer.Serialize(BibliotekData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(dataFilPath, jsonData);
    }



    public List<Bok> HämtaAllaBöcker()
    {
        BibliotekData.Böcker.ForEach(b => Console.WriteLine(b.Titel, b.Författare, b.Genre, b.ISBN, b.Publiceringsår, b.Betyg));

        return BibliotekData.Böcker;
    }

    public List<Författare> HämtaAllaFörfattare()
    {
        BibliotekData.Författare.ForEach(f => Console.WriteLine(f.Namn, f.Land));
        return BibliotekData.Författare;
    }




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
        List<int> betyg = new List<int> { 5, 4, 3 };
        Bok nyBok = new Bok(titel, författareNamn, genre, isbn, publiceringsår, Id, betyg);
        BibliotekData.Böcker.Add(nyBok);
        SparaData();
        Console.WriteLine($"Boken \"{titel}\" har lagts till i biblioteket.");

    }
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
        BibliotekData.Författare.Add(nyFörfattare);
        SparaData();
        Console.WriteLine($"Författaren \"{namn}\" har lagts till i biblioteket.");

    }
    public void UppdateBook()
    {
        Console.Write("Ange titeln på boken som ska uppdateras: ");
        string titel = Console.ReadLine();

        var bok = BibliotekData.Böcker.FirstOrDefault(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
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
    public void UppdateraFörfattare()
    {
        Console.Write("Ange namnet på författaren som ska uppdateras: ");
        string namn = Console.ReadLine();

        var förf = BibliotekData.Författare.FirstOrDefault(f => f.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
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
    public void TaBortBok()
    {
        Console.Write("Ange titeln på boken som ska tas bort: ");
        string titel = Console.ReadLine();

        var bok = BibliotekData.Böcker.FirstOrDefault(b => b.Titel.Equals(titel, StringComparison.OrdinalIgnoreCase));
        if (bok != null)
        {
            BibliotekData.Böcker.Remove(bok);
            Console.WriteLine($"Boken \"{bok.Titel}\" har tagits bort.");
        }
        else
        {
            Console.WriteLine("Boken hittades inte.");
        }

    }
    public void TaBortFörfattare()
    {
        Console.Write("Ange namnet på författaren som ska tas bort: ");
        string namn = Console.ReadLine();

        var förf = BibliotekData.Författare.FirstOrDefault(f => f.Namn.Equals(namn, StringComparison.OrdinalIgnoreCase));
        if (förf != null)
        {
            BibliotekData.Författare.Remove(förf);
            Console.WriteLine($"Författaren \"{förf.Namn}\" har tagits bort.");
        }
        else
        {
            Console.WriteLine("Författaren hittades inte.");
        }

    }
    public void ListaAllaBöckerOchFörfattare()
    {
        foreach (var bok in BibliotekData.Böcker)

        {

            Console.WriteLine($"Titel: {bok.Titel}, Författare: {bok.Författare}, Genre:{bok.Genre},ISBN:{bok.ISBN},Publiceringsår{bok.Publiceringsår},Genomsnittbetyg {bok.GenomsnittligtBetyg:F2}");
        }

        foreach (var förf in BibliotekData.Författare)


        {

            Console.WriteLine($"Namn: {förf.Namn}, Land {förf.Land:F2}");
        }
    }


    public void SökOchFiltreraBöcker()
    {
        var data = HämtaAllaBöcker();

        Console.WriteLine("Hej vill du söka efter en Bok klicka på 1 ifall du vill filtrera efter titel, författare eller genre klicka på två");
        string input = Console.ReadLine()!;


        if (input == "1")
        {
            Console.Write("Ange titeln på boken du söker: ");
            string sökTitel = Console.ReadLine()!;

            var söktaBöcker = BibliotekData.Böcker
                .Where(b => b.Titel.Contains(sökTitel, StringComparison.OrdinalIgnoreCase))
                .Select(b => new
                {
                    b.Titel,
                    FörfattareNamn = b.Författare,
                    GenomsnittligtBetyg = b.Betyg.Count > 0 ? b.Betyg.Average() : 0
                })
                .ToList();

            if (söktaBöcker.Any())
            {
                Console.WriteLine("Hittade följande böcker:");
                foreach (var bok in söktaBöcker)
                {
                    Console.WriteLine($"- {bok.Titel} av {bok.FörfattareNamn} (Betyg: {bok.GenomsnittligtBetyg:F1})");
                }
            }
            else
            {
                Console.WriteLine("Ingen bok hittades med den titeln.");
            }
        }
        else if (input == "2")
        {
            Console.WriteLine("Vill du filtrera efter titel, författare eller genre? (Skriv 'titel', 'författare' eller 'genre')");
            string filterType = Console.ReadLine()!.ToLower();

            IEnumerable<Bok> filtreradeBöcker = Enumerable.Empty<Bok>();

            switch (filterType)
            {
                case "titel":
                    Console.Write("Ange del av titeln: ");
                    string delAvTitel = Console.ReadLine()!;
                    filtreradeBöcker = BibliotekData.Böcker.Where(b => b.Titel.Contains(delAvTitel, StringComparison.OrdinalIgnoreCase));
                    break;

                case "författare":
                    Console.Write("Ange författarens namn: ");
                    string författarNamn = Console.ReadLine()!;
                    filtreradeBöcker = BibliotekData.Böcker.Where(b => b.Författare.Contains(författarNamn, StringComparison.OrdinalIgnoreCase) == true);
                    break;

                case "genre":
                    Console.Write("Ange genre: ");
                    string genre = Console.ReadLine()!;
                    filtreradeBöcker = BibliotekData.Böcker.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
                    break;

                default:
                    Console.WriteLine("Ogiltigt alternativ. Försök igen.");
                    return;
            }

            if (filtreradeBöcker.Any())
            {
                Console.WriteLine("Filtrerade böcker:");
                foreach (var bok in filtreradeBöcker)
                {
                    double genomsnittligtBetyg = bok.Betyg.Count > 0 ? bok.Betyg.Average() : 0;
                    Console.WriteLine($"- {bok.Titel} av {bok.Författare} (Betyg: {genomsnittligtBetyg:F1})");
                }
            }
            else
            {
                Console.WriteLine("Inga böcker hittades som matchar dina kriterier.");
            }
        }
        else
        {
            Console.WriteLine("Ogiltig inmatning, vänligen försök igen.");
        }
    }
    public void HanteraBetyg()
    {
        var data = HämtaAllaBöcker();
        Console.Write("Ange titeln på boken du vill betygsätta: ");
        string bokTitel = Console.ReadLine();

        Console.Write("Ange betyg (1-5): ");
        if (!int.TryParse(Console.ReadLine(), out int nyttBetyg) || nyttBetyg < 1 || nyttBetyg > 5)
        {
            Console.WriteLine("Betyget måste vara ett heltal mellan 1 och 5.");
            return;
        }
        var bok = BibliotekData.Böcker.FirstOrDefault(b => b.Titel.Equals(bokTitel, StringComparison.OrdinalIgnoreCase));

        if (bok != null)
        {
            bok.Betyg.Add(nyttBetyg);
            Console.WriteLine($"Betyget {nyttBetyg} har lagts till för boken \"{bok.Titel}\".");
        }
        else
        {
            Console.WriteLine($"Boken med titeln \"{bokTitel}\" hittades inte.");
            return;
        }
    }
}