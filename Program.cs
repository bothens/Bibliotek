namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej, välkommen till mitt bibliotek!");
            bool start = true;
                Bibliotek bibliotek = new Bibliotek();
                bibliotek.LaddaData();
                while (start)
                {

                    Console.WriteLine("== Bibliotekssystem ==");
                    Console.WriteLine("1. Lägg till ny bok");
                    Console.WriteLine("2. Lägg till ny författare");
                    Console.WriteLine("3. Uppdatera bokdetaljer");
                    Console.WriteLine("4. Uppdatera författardetaljer");
                    Console.WriteLine("5. Ta bort bok");
                    Console.WriteLine("6. Ta bort författare");
                    Console.WriteLine("7. Lista alla böcker och författare");
                    Console.WriteLine("8. Sök och sortera böcker");
                    Console.WriteLine("9. Lämna och se betyg");
                    Console.WriteLine("10. Avsluta programmet");
                    Console.WriteLine("Välj ett alternativ (1-8): ");


                    string input = Console.ReadLine()!;

                    switch (input)
                    {
                        case "1":
                            bibliotek.AddBook();
                            bibliotek.SparaData();
                            break;

                        case "2":
                            bibliotek.AddAuthor();
                            bibliotek.HämtaAllaFörfattare();
                            bibliotek.SparaData();
                            break;

                        case "3":
                            bibliotek.UppdateBook();
                            bibliotek.HämtaAllaBöcker();
                            bibliotek.SparaData();
                            break;

                        case "4":
                            bibliotek.UppdateraFörfattare();
                            bibliotek.SparaData();
                            break;

                        case "5":
                            bibliotek.TaBortBok();
                            bibliotek.HämtaAllaBöcker();
                            bibliotek.SparaData();
                            break;

                        case "6":
                            bibliotek.TaBortFörfattare();
                            bibliotek.HämtaAllaFörfattare();
                            bibliotek.SparaData();
                            break;

                        case "7":
                        bibliotek.LaddaData();
                        bibliotek.ListaAllaBöckerOchFörfattare();
                            bibliotek.HämtaAllaBöcker();
                            bibliotek.HämtaAllaFörfattare();
                        bibliotek.SparaData();

                        break;

                        case "8":
                            bibliotek.SökOchFiltreraBöcker();
                            bibliotek.HämtaAllaFörfattare();
                            bibliotek.HämtaAllaBöcker();
                            bibliotek.SparaData();
                            break;

                        case "9":
                            bibliotek.HanteraBetyg();
                            bibliotek.SparaData();
                            break;


                        case "10":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Fel inmatning, försök igen");
                            break;

                    }
                }

        }
    }
}
