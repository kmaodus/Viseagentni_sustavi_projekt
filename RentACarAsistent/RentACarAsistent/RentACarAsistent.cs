using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static RentACarAsistent.Enums;

namespace RentACarAsistent
{
    public class RentACarAsistent<T> : Bdi<T> where T : Dictionary<string, string>
    {
        public RentACarAsistent(IEnumerable<Koncept<TipUvjerenja, T>> uvjerenja) : base(uvjerenja)
        { }

        public T DohvatiPlan(IEnumerable<Koncept<TipŽelja, T>> želje)
        {
            return IzborSredstava(IzborCiljeva(želje));
        }


        protected override T IzborSredstava(IEnumerable<Koncept<TipIntencije, T>> intencije)
        {
            return intencije.FirstOrDefault() == null ? null : intencije.First().KonceptReprezentacija;
        }

        protected override IEnumerable<Koncept<TipIntencije, T>> IzborCiljeva(IEnumerable<Koncept<TipŽelja, T>> želje)
        {
            return TraziAutomobil(želje.ToList());
        }


        private IEnumerable<Koncept<TipIntencije, T>> TraziAutomobil<T>(List<Koncept<TipŽelja, T>> želje) where T : Dictionary<string, string>
        {
            var željeniGrad = želje.FirstOrDefault(ž => ž.Labela == TipŽelja.Grad);
            var željeniProizvođač = želje.First(ž => ž.Labela == TipŽelja.Proizvođač);
            var željeniModel = želje.First(ž => ž.Labela == TipŽelja.Model);
            var željeniMaxBudžet = želje.First(ž => ž.Labela == TipŽelja.BudžetUKunama);
            var željeniDatum = želje.First(ž => ž.Labela == TipŽelja.Datum);
            var željenaSnagaMotora = želje.First(ž => ž.Labela == TipŽelja.SnagaMotoraHP);
            var željenaVrstaGoriva = želje.FirstOrDefault(ž => ž.Labela == TipŽelja.VrstaGoriva);

            var gradUnajmljivanja = željeniGrad.KonceptReprezentacija["grad"].Split(',');
            var proizvodacZaUnajmiti = željeniProizvođač.KonceptReprezentacija["proizvodac"].Split(',');
            var modelZaUnajmiti = željeniModel.KonceptReprezentacija["model"].Split(',');
            var maxBudžet = double.Parse(željeniMaxBudžet.KonceptReprezentacija["maxKuna"]);
            DateTime datumOd = DateTime.Parse(željeniDatum.KonceptReprezentacija["datumOd"], new CultureInfo("hr-HR"));
            var brojDana = int.Parse(željeniDatum.KonceptReprezentacija["brojDana"]);
            var snagaMotora = int.Parse(željenaSnagaMotora.KonceptReprezentacija["snagaMotora"]);
            var vrstaGoriva = željenaVrstaGoriva.KonceptReprezentacija["gorivo"].Split(',');

            var rentACarPaketi = Uvjerenja.Where(b => b.Labela == TipUvjerenja.RentACarPaket);
            var rezultat = new List<Koncept<TipIntencije, T>>();

            foreach (var rentACarPaket in rentACarPaketi)
            {
                var data = rentACarPaket.KonceptReprezentacija as Dictionary<string, string>;
                var grad = data["grad"].Split(',');
                var proizvodacAuta = data["proizvodac"].Split(',');
                var modelAuta = data["model"].Split(',');
                DateTime dostupnostNajma = DateTime.Parse(data["dostupno"], new CultureInfo("hr-HR"));
                var brojDanaIznajmljivanja = int.Parse(data["dana"]);
                var cijena = double.Parse(data["cijena"]);
                var pogonskoGorivo = data["gorivo"].Split(',');
                var snaga = int.Parse(data["snagaMotora"]);

                if (brojDanaIznajmljivanja <= brojDana &&
                grad.Intersect(gradUnajmljivanja).Count() == grad.Length &&
                modelAuta.Intersect(modelZaUnajmiti).Count() == modelAuta.Length &&
                proizvodacAuta.Intersect(proizvodacZaUnajmiti).Count() == proizvodacAuta.Length &&
                dostupnostNajma <= datumOd &&
                cijena <= maxBudžet &&
                snaga >= snagaMotora &&
                pogonskoGorivo.Intersect(vrstaGoriva).Count() == pogonskoGorivo.Length)
                {
                    rezultat.Add(new Koncept<TipIntencije, T>(TipIntencije.RezervirajRentACarPaket,
                    rentACarPaket.KonceptReprezentacija as T));
                }
            }
            return rezultat;
        }
    }
}
