using System;
using System.Collections.Generic;
using System.Linq;
using static RentACarAsistent.Enums;

namespace RentACarAsistent
{
    class Program
    {
        static void Main(string[] args)
        {
            #region uvjerenja

            var uvjerenja = new List<Koncept<TipUvjerenja, Dictionary<string, string>>>
            {
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Sixt" },
                     { "dostupno" , "04-01-2021" }, { "dana" , "10"}, { "modeli", "540" }, { "proizvodac", "BMW" }, { "snagaMotora", "190" }, { "gorivo", "benzin" },
                     { "cijena" , "800"}, { "webPage" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Carwiz" }, { "dostupno" , "04-01-2021" }, { "dana" , "10" },
                     { "modeli", "Insignia" }, { "proizvodac", "Opel" }, { "snagaMotora", "140" }, { "gorivo", "benzin" },
                     { "cijena" , "400"}, { "webPage" , "www.carwiz.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Sixt" },
                     { "dostupno" , "03-01-2021" }, { "dana" , "14"}, { "modeli", "520" }, { "proizvodac", "BMW" }, { "snagaMotora", "190" }, { "gorivo", "dizel" },
                     { "cijena" , "800"}, { "webPage" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Sixt" },
                     { "dostupno" , "05-01-2021" }, { "dana" , "10"}, { "modeli", "" }, { "proizvodac", "Audi, VW" }, { "snagaMotora", "150" }, { "gorivo", "dizel" },
                     { "cijena" , "350"}, { "webPage" , "www.sixt.hr" }}),
            };
            #endregion

            var rentACarAsistent = new RentACarAsistent<Dictionary<string, string>>(uvjerenja);

            bool ugasi = false;

            while (!ugasi)
            {
                Console.WriteLine(Environment.NewLine);
                string separator = new string('=', 110);
                Console.WriteLine("\tRent A Car Asistent \n");
                Console.WriteLine(separator);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Unesite proizvođača vozila:  npr. BMW, Audi, Mercedes Benz, Opel, VW...");
                string proizvodacAuta = Console.ReadLine();
                Console.WriteLine("Unesite model auta: ");
                string modelAuta = Console.ReadLine();
                Console.WriteLine("Unesi maksimalni budžet u kunama: ");
                decimal maxBudžet = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Unesi broj dana najma: ");
                int brojDanaNajma = int.Parse(Console.ReadLine());
                Console.WriteLine("Unesi datum pocetka najma (dd-mm-yyyy): ");
                string datum = Console.ReadLine();
                Console.WriteLine("Unesi snagu motora u HP (Horsepower): ");
                int snaga = int.Parse(Console.ReadLine());
                Console.WriteLine("Unesi vrstu goriva (benzin, dizel, struja, hibrid): ");
                string gorivo = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(separator);

                var korisnikoveŽelje = new List<Koncept<TipŽelja, Dictionary<string, string>>>
            {
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Proizvođač, new Dictionary<string, string> { { "proizvodac", proizvodacAuta } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Model, new Dictionary<string, string> { { "modeli", modelAuta } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.BudžetUKunama, new Dictionary<string, string> { {"maxKuna", maxBudžet.ToString() } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Datum, new Dictionary<string, string> { { "datumOd", datum }, { "brojDana", brojDanaNajma.ToString() } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.SnagaMotoraHP, new Dictionary<string, string> {{ "snagaMotora", snaga.ToString() }}),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.VrstaGoriva, new Dictionary<string, string> {{ "gorivo", gorivo }})
            };

                var rentACarPonuda = rentACarAsistent.DohvatiPlan(korisnikoveŽelje);

                if (rentACarPonuda == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Žao mi je, ali nemam ponudu koja odgovara Vašim željama..");
                    Console.WriteLine("Ugasi program? (da/ne)");
                    Console.ResetColor();
                    if (Console.ReadLine() == "da")
                    {
                        ugasi = true;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--- Ponuda za Vas ---");
                    Console.ResetColor();
                    Console.WriteLine(separator);
                    Console.WriteLine($"\tProizvođač: " + rentACarPonuda.First(x => x.Key == "proizvodac").Value.Split(',')[0]);
                    Console.WriteLine($"\tModel: " + rentACarPonuda.First(x => x.Key == "modeli").Value.Split(',')[0]);
                    Console.WriteLine($"\tSnaga motora: " + rentACarPonuda.First(x => x.Key == "snagaMotora").Value.Split(',')[0] + " konja");
                    Console.WriteLine($"\tVrsta goriva: " + rentACarPonuda.First(x => x.Key == "gorivo").Value.Split(',')[0]);
                    Console.WriteLine($"\tCijena najma: " + rentACarPonuda.First(x => x.Key == "cijena").Value.Split(',')[0] + " kuna");
                    Console.WriteLine($"\tDostupno od datuma: " + rentACarPonuda.First(x => x.Key == "dostupno").Value.Split(',')[0]);
                    Console.WriteLine($"\tMinimalan broj dana najma: " + rentACarPonuda.First(x => x.Key == "dana").Value.Split(',')[0] + " dana");
                    Console.WriteLine($"\t{$"Web stranica: "}{rentACarPonuda.First(x => x.Key == "webPage").Value.Split(',')[0]}");

                    Console.WriteLine(separator);
                    Console.WriteLine("\nUgasi program? (da/ne)");
                    if (Console.ReadLine() == "da")
                    {
                        ugasi = true;
                    }
                }
            }
        }
    }
}
