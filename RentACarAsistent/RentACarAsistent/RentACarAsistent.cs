using System.Collections.Generic;
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
            return MeansEndReasoning(Deliberate(želje));
        }

        protected override IEnumerable<Koncept<TipIntencije, T>> Deliberate(IEnumerable<Koncept<TipŽelja, T>> želje)
        {
            return TraziAutomobil(želje.ToList());
        }

        protected override T MeansEndReasoning(IEnumerable<Koncept<TipIntencije, T>> intencije)
        {
            return intencije.FirstOrDefault() == null ? null : intencije.First().KonceptReprezentacija;
        }


        private IEnumerable<Koncept<TipIntencije, T>> TraziAutomobil<T>(List<Koncept<TipŽelja, T>> želje) where T : Dictionary<string, string>
        {
            var željeniProizvođač = želje.First(ž => ž.Labela == TipŽelja.Proizvođač);
            var željeniModel = želje.First(ž => ž.Labela == TipŽelja.Model);
            var željeniMaxBudžet = želje.First(ž => ž.Labela == TipŽelja.BudžetUKunama);
            var željeniDatum = želje.First(ž => ž.Labela == TipŽelja.Datum);
            //var željenaVrstaGoriva = želje.First(ž => ž.Labela == TipŽelja.VrstaGoriva);
            var željenaSnagaMotora = želje.First(ž => ž.Labela == TipŽelja.SnagaMotoraHP);

            var proizvodacZaUnajmiti = željeniProizvođač.KonceptReprezentacija["proizvodac"].Split(',');
            var modeliZaUnajmiti = željeniModel.KonceptReprezentacija["modeli"].Split(',');
            var maxBudžet = double.Parse(željeniMaxBudžet.KonceptReprezentacija["maxKuna"]);
            var datumOd = željeniDatum.KonceptReprezentacija["datumOd"];
            var brojDana = int.Parse(željeniDatum.KonceptReprezentacija["brojDana"]);
            //var vrstaGoriva = željenaVrstaGoriva.KonceptReprezentacija["vrstaGoriva"];
            var snagaMotora = int.Parse(željenaSnagaMotora.KonceptReprezentacija["snagaMotora"]);

            var rentACarPaketi = Uvjerenja.Where(b => b.Labela == TipUvjerenja.RentACarPaket);
            var rezultat = new List<Koncept<TipIntencije, T>>();

            foreach (var rentACarPaket in rentACarPaketi)
            {
                var data = rentACarPaket.KonceptReprezentacija as Dictionary<string, string>;
                var proizvodacAuta = data["proizvodac"].Split(',');
                var modeliAuta = data["modeli"].Split(',');
                var dostupnostNajma = data["dostupno"];
                var brojDanaIznajmljivanja = int.Parse(data["dana"]);
                var cijena = double.Parse(data["cijena"]);
                //var pogonskoGorivo = data["pogonskoGorivo"];
                var snaga = int.Parse(data["snagaMotora"]);

                if (brojDanaIznajmljivanja <= brojDana &&
                modeliAuta.Intersect(modeliZaUnajmiti).Count() == modeliAuta.Length &&
                proizvodacAuta.Intersect(proizvodacZaUnajmiti).Count() == proizvodacAuta.Length &&
                dostupnostNajma == datumOd &&
                cijena < maxBudžet &&
                snaga >= snagaMotora)
                {
                    rezultat.Add(new Koncept<TipIntencije, T>(TipIntencije.RezervirajRentACarPaket,
                    rentACarPaket.KonceptReprezentacija as T));
                }
            }
            return rezultat;
        }
    }
}
