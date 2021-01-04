using System.Collections.Generic;
using static RentACarAsistent.Enums;

namespace RentACarAsistent
{
    public abstract class Bdi<T>
    {
        public IEnumerable<Koncept<TipUvjerenja, T>> Uvjerenja { get; set; }
        public IEnumerable<Koncept<TipŽelja, T>> Želje { get; set; }
        public IEnumerable<Koncept<TipŽelja, T>> Intencije { get; set; }

        protected Bdi(IEnumerable<Koncept<TipUvjerenja, T>> uvjerenja)
        {
            Uvjerenja = new List<Koncept<TipUvjerenja, T>>(uvjerenja);
            Želje = new List<Koncept<TipŽelja, T>>();
            Intencije = new List<Koncept<TipŽelja, T>>();
        }
        protected abstract IEnumerable<Koncept<TipIntencije, T>> Deliberate(IEnumerable<Koncept<TipŽelja, T>> želje);
        protected abstract T MeansEndReasoning(IEnumerable<Koncept<TipIntencije, T>> intencije);
    }
}
