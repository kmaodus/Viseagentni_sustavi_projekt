using System;
using System.Collections.Generic;
using static RentACarAsistent.Enums;

namespace RentACarAsistent
{
    class Program
    {
        static void Main(string[] args)
        {
            var beliefs = new List<Koncept<TipUvjerenja, Dictionary<string, string>>>
            {
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Viša Klasa" },
                     { "dostupno" , "04-01-2021" }, { "dana" , "10"}, { "modeli", "540" }, { "proizvodac", "BMW" }, { "snagaMotora", "190" },
                     { "cijena" , "800"}, { "Sixt" , "www.sixt.hr" }}),
                     new Koncept<TipUvjerenja, Dictionary<string, string>>(
                     TipUvjerenja.RentACarPaket,
                     new Dictionary<string, string> { { "ponuda", "Srednja Klasa" },
                     { "dostupno" , "04-01-2021" }, { "dana" , "10"}, { "modeli", "Insignia" }, { "proizvodac", "Opel" }, { "snagaMotora", "140" },
                     { "cijena" , "400"}, { "CARWIZ" , "www.carwiz.hr" }}),

            };
            var rentACarAsistent = new RentACarAsistent<Dictionary<string, string>>(beliefs);

            Console.WriteLine(Environment.NewLine);
            string separator = new string('=', 110);
            Console.WriteLine("\tRent A Car Asistent \n");
            Console.WriteLine(separator);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Unesite proizvođača vozila: ");
            string proizvodacAuta = Console.ReadLine();
            Console.WriteLine("Unesite model auta: ");
            string modelAuta = Console.ReadLine();
            Console.WriteLine("Unesi maksimalni budžet: ");
            //Decimal.TryParse(Console.ReadLine(), out decimal maxBudžet);
            decimal maxBudžet = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Unesi broj dana najma: ");
            int brojDanaNajma = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesi datum pocetka najma (dd-mm-yyyy): ");
            string datum = Console.ReadLine();
            Console.WriteLine("Unesi snagu motora u HP (Horsepower): ");
            int snaga = int.Parse(Console.ReadLine());
            //Int32.TryParse(Console.ReadLine(), out int brojDanaNajma);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(separator);

            var korisnikoveŽelje = new List<Koncept<TipŽelja, Dictionary<string, string>>>
            {
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Proizvođač, new Dictionary<string, string> { { "proizvodac",proizvodacAuta } }),
                //new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Proizvođač, new Dictionary<string, string> { { "proizvodac", "BMW, Audi, Mercedes Benz" } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Model, new Dictionary<string, string> { { "modeli", modelAuta } }),
                //new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Model, new Dictionary<string, string> { { "modeli", "" +  "540" } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.BudžetUKunama, new Dictionary<string, string> { {"maxKuna", maxBudžet.ToString() } }),
                //new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.BudžetUKunama, new Dictionary<string, string> { {"maxKuna", "1000" } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.Datum, new Dictionary<string, string> { { "datumOd", datum }, { "brojDana", brojDanaNajma.ToString() } }),
                new Koncept<TipŽelja, Dictionary<string, string>>(TipŽelja.SnagaMotoraHP, new Dictionary<string, string> {{ "snagaMotora", snaga.ToString() }})
            };

            var rentACarPonuda = rentACarAsistent.DohvatiPlan(korisnikoveŽelje);

            Console.WriteLine(rentACarPonuda == null ?
            "Sorry, nemam plan za tebe" : IspišiPonudu(rentACarPonuda));
            Console.ReadLine();


        }
        static string IspišiPonudu(Dictionary<string, string> toPrint)
        {
            var result = "";
            foreach (var keyValue in toPrint)
            {
                result += keyValue.Key + ", " + keyValue.Value + '\n';
            }
            return result;
        }


        //private static void PrikaziOpcijeKorisnika()
        //{
        //    string separator = new string('=', 110);
        //    Console.WriteLine(Environment.NewLine);
        //    Console.WriteLine(separator);
        //    Console.WriteLine("Rent A Car Asistent \n");
        //    Console.WriteLine("\tUnesite marku vozila: ");
        //    string proizvodacAuta = Console.ReadLine();
        //    Console.WriteLine("\tUnesite model auta: ");
        //    string modelAuta = Console.ReadLine();
        //    Console.WriteLine("\tUnesi maksimalni budžet: ");
        //    Decimal.TryParse(Console.ReadLine(), out decimal maxBudžet);
        //    //decimal maxBudžet = Console.ReadLine();
        //    Console.WriteLine("\tUnesi broj dana najma: ");
        //    //int brojDanaNajma = Console.ReadLine();
        //    Int32.TryParse(Console.ReadLine(), out int brojDanaNajma);
        //    Console.WriteLine(separator);
        //}
    }
}
