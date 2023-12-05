namespace Szamolasok
{
    public class Szamol
    {
        public double a;
        public bool szerkeszhetoE;

        public Szamol(double a)
        {
            this.a = a;
        }
        public double Kivonas(double b)
        {
            return a - b;
        }
        public double Szorzas(double b)
        {
            return a * b;
        }
        public double Gyok(double b)
        {
            return Math.Pow(a, b);
        }
        public bool SzerkezhetoEaHaromszog(double bef1, double bef2, double atf)
        {
            if ((bef1 + bef2) > atf)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}