using RentACarAsistent.Alati;
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
                     new Dictionary<string, string> { { "ponuda", "Sixt" },{ "dostupno" , "04-01-2021" }, { "dana" , "10"}, { "snagaMotora", "335" }, { "gorivo", "benzin" },
                     { "model", "540" }, { "proizvodac", "BMW" }, { "grad", "Zagreb" },
                     { "cijena" , "400"}, { "webPage" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Sixt" },{ "dostupno" , "21-02-2021" }, { "dana" , "7"}, { "snagaMotora", "394" }, { "gorivo", "hibrid" },
                     { "model", "545e" }, { "proizvodac", "BMW" }, { "grad", "Zagreb" },
                     { "cijena" , "400"}, { "webPage" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Carwiz" }, { "grad", "Varaždin" },
                     { "dostupno" , "01-01-2021" }, { "dana" , "5"}, { "model", "Model S" }, { "proizvodac", "Tesla" }, { "snagaMotora", "260" }, { "gorivo", "struja" },
                     { "cijena" , "300"}, { "webPage" , "www.carwiz.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "UniRent" }, { "grad", "Slavonski Brod" },
                     { "dostupno" , "10-01-2021" }, { "dana" , "2"}, { "model", "Insignia GSi" }, { "proizvodac", "Opel" }, { "snagaMotora", "80" }, { "gorivo", "benzin" },
                     { "cijena" , "300"}, { "webPage" , "www.uni-rent.net" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "ORYX" }, { "grad", "Split" },
                     { "dostupno" , "02-02-2021" }, { "dana" , "2"}, { "model", "E63S" }, { "proizvodac", "Mercedes Benz" }, { "snagaMotora", "603" }, { "gorivo", "benzin" },
                     { "cijena" , "750"}, { "webPage" , "www.oryx-rent.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Carwiz" }, { "dostupno" , "04-01-2021" }, { "dana" , "10" },
                     { "model", "Insignia" }, { "proizvodac", "Opel" }, { "snagaMotora", "140" }, { "gorivo", "benzin" }, { "grad", "Zagreb" },
                     { "cijena" , "90"}, { "webPage" , "www.carwiz.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Sixt" }, { "grad", "Zagreb" },
                     { "dostupno" , "03-01-2021" }, { "dana" , "14"}, { "model", "520" }, { "proizvodac", "BMW" }, { "snagaMotora", "190" }, { "gorivo", "dizel" },
                     { "cijena" , "100"}, { "webPage" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Sixt" }, { "grad", "Zagreb" },
                     { "dostupno" , "05-01-2021" }, { "dana" , "10"}, { "model", "" }, { "proizvodac", "Audi, VW" }, { "snagaMotora", "150" }, { "gorivo", "dizel" },
                     { "cijena" , "350"}, { "webPage" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Carwiz" }, { "grad", "Zagreb" },
                     { "dostupno" , "04-01-2021" }, { "dana" , "7"}, { "model", "A3" }, { "proizvodac", "Audi" }, { "snagaMotora", "115" }, { "gorivo", "dizel" },
                     { "cijena" , "99"}, { "webPage" , "www.carwiz.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Carwiz" }, { "grad", "Zagreb" },
                     { "dostupno" , "04-01-2021" }, { "dana" , "5"}, { "model", "Passat" }, { "proizvodac", "VW" }, { "snagaMotora", "130" }, { "gorivo", "dizel" },
                     { "cijena" , "105"}, { "webPage" , "www.carwiz.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "UniRent" }, { "grad", "Osijek" },
                     { "dostupno" , "04-01-2021" }, { "dana" , "4"}, { "model", "Astra" }, { "proizvodac", "Opel" }, { "snagaMotora", "80" }, { "gorivo", "benzin" },
                     { "cijena" , "50"}, { "webPage" , "www.uni-rent.net" }}),

            };
            #endregion

            var rentACarAsistent = new RentACarAsistent<Dictionary<string, string>>(uvjerenja);

            bool ugasi = false;

            while (!ugasi)
            {
                Console.WriteLine(Environment.NewLine);
                string separator = new string('=', 110);

                Zapisnik.Ispis(Zapisnik.OBAVIJEST, "\tRent A Car Asistent \n");
                Zapisnik.Ispis(Zapisnik.OBAVIJEST, $"{separator}\n");

                Console.WriteLine("\nUnesite grad (Zagreb, Varazdin, Slavonski Brod, Split, Osijek): ");
                string grad = Console.ReadLine();
                Console.WriteLine("\nUnesite proizvođača vozila:  npr. BMW, Audi, Mercedes Benz, Opel, Tesla, VW...");
                string proizvodacAuta = Console.ReadLine();
                Console.WriteLine("\nUnesite model auta: ");
                string modelAuta = Console.ReadLine();
                Console.WriteLine("\nUnesi maksimalni budžet u kunama po danu: ");
                decimal maxBudžet = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nUnesi broj dana najma: ");
                int brojDanaNajma = int.Parse(Console.ReadLine());
                Console.WriteLine("\nUnesi datum pocetka najma (dd-mm-gggg): ");
                string datum = Console.ReadLine();
                Console.WriteLine("\nUnesi snagu motora u HP (Horsepower): ");
                int snaga = int.Parse(Console.ReadLine());
                Console.WriteLine("\nUnesi vrstu goriva (benzin, dizel, struja, hibrid): ");
                string gorivo = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(separator);

                var korisnikoveŽelje = new List<Koncept<TipŽelja, Dictionary<string, string>>>
            {
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Grad, new Dictionary<string, string> { { "grad", grad } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Proizvođač, new Dictionary<string, string> { { "proizvodac", proizvodacAuta } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Model, new Dictionary<string, string> { { "model", modelAuta } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.BudžetUKunama, new Dictionary<string, string> { {"maxKuna", maxBudžet.ToString() } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Datum, new Dictionary<string, string> { { "datumOd", datum }, { "brojDana", brojDanaNajma.ToString() } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.SnagaMotoraHP, new Dictionary<string, string> {{ "snagaMotora", snaga.ToString() }}),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.VrstaGoriva, new Dictionary<string, string> {{ "gorivo", gorivo }})
            };

                var rentACarPonuda = rentACarAsistent.DohvatiPlan(korisnikoveŽelje);

                if (rentACarPonuda == null)
                {
                    Zapisnik.Ispis(Zapisnik.UPOZORENJE, "Žao mi je, ali nemam ponudu koja odgovara Vašim željama..");
                    Zapisnik.Ispis(Zapisnik.UPOZORENJE, "Ugasi program? (da/ne)");
                    if (Console.ReadLine() == "da")
                    {
                        ugasi = true;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Zapisnik.Ispis(Zapisnik.USPJEH, "--- Ponuda za Vas ---");
                    Zapisnik.Ispis(Zapisnik.USPJEH, separator);
                    Console.WriteLine($"\tGrad: " + rentACarPonuda.First(x => x.Key == "grad").Value.Split(',')[0]);
                    Console.WriteLine($"\tProizvođač: " + rentACarPonuda.First(x => x.Key == "proizvodac").Value.Split(',')[0]);
                    Console.WriteLine($"\tModel: " + rentACarPonuda.First(x => x.Key == "model").Value.Split(',')[0]);
                    Console.WriteLine($"\tSnaga motora: " + rentACarPonuda.First(x => x.Key == "snagaMotora").Value.Split(',')[0] + " konja");
                    Console.WriteLine($"\tVrsta goriva: " + rentACarPonuda.First(x => x.Key == "gorivo").Value.Split(',')[0]);
                    Console.WriteLine($"\tCijena najma: " + rentACarPonuda.First(x => x.Key == "cijena").Value.Split(',')[0] + " kuna/dan");
                    Console.WriteLine($"\tDostupno od datuma: " + rentACarPonuda.First(x => x.Key == "dostupno").Value.Split(',')[0]);
                    Console.WriteLine($"\tMinimalan broj dana najma: " + rentACarPonuda.First(x => x.Key == "dana").Value.Split(',')[0] + " dana");
                    Console.WriteLine($"\t{$"Web stranica: "}{rentACarPonuda.First(x => x.Key == "webPage").Value.Split(',')[0]}");

                    Zapisnik.Ispis(Zapisnik.USPJEH, separator);
                    Zapisnik.Ispis(Zapisnik.OBAVIJEST, "\nUgasi program? (da/ne)");
                    if (Console.ReadLine() == "da")
                    {
                        ugasi = true;
                    }
                }
            }
        }
    }
}
