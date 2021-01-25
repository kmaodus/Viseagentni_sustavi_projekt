namespace RentACarAsistent
{
    public class Koncept<TK, T>
    {
        public TK Labela;
        public T KonceptReprezentacija;

        public Koncept(TK labela, T konceptReprezentacija)
        {
            Labela = labela;
            KonceptReprezentacija = konceptReprezentacija;
        }
    }
}
