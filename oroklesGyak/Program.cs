using System.Reflection.Metadata;

namespace oroklesGyak
{
    interface IArlap
    {
        double MennyibeKerul();
    }

    abstract class Peksutemeny : IArlap
    {
        protected int mennyiseg;
        public double alapar;

        protected Peksutemeny(int mennyiseg, double alapar)
        {
            this.mennyiseg = mennyiseg;
            this.alapar = alapar;
        }

        public abstract void Megkostol();

        public double MennyibeKerul()
        {
            return this.alapar * this.mennyiseg;
        }
        public override string ToString()
        {
            return $"{this.mennyiseg}db - {MennyibeKerul()}Ft";
        }
    }

    class Pogacsa : Peksutemeny
    {
        public Pogacsa(int mennyiseg, double alapar) : base(mennyiseg, alapar)
        {
        }

        public override void Megkostol()
        {
            this.mennyiseg /= 2;
        }
        public override string ToString()
        {
            return $"Pogacsa {base.ToString()}";
        }
    }

    class Kave : IArlap
    {
        private bool habosE;
        const double CSESZEKAVE = 100;
        public double ar;

        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

        public double MennyibeKerul()
        {
            return habosE ? CSESZEKAVE * 1.5 : CSESZEKAVE;
        }

        public override string ToString()
        {
            return $"{(habosE ? "Habos" : "Nem habos")} kávé {MennyibeKerul()}";
        }
    }
    internal class Futtato
    {
        static List<IArlap> arlap = new List<IArlap>();
        static void Vasarlok(string utvonal)
        {
            foreach (var line in File.ReadAllLines(utvonal))
            {
                string[] x = line.Split(' ');
                if (x[0] == "Pogacsa") arlap.Add(new Pogacsa(int.Parse(x[1]), double.Parse(x[2])));
                else arlap.Add(new Kave((x[1] == "habos" ? 1 : 0)));
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}