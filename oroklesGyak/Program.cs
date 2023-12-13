using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

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

        public bool HabosE { get => habosE; set => habosE = value; }

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
            return $"{(habosE ? "Habos" : "Nem habos")} kávé {MennyibeKerul()}Ft";
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
                else arlap.Add(new Kave((x[1] == "habos" ? true : false)));
            }
        }
        static void Main(string[] args)
        {
            Vasarlok("Pekseg.txt");

            //(1)mennyi entry van az arlapon
            Console.WriteLine($"Arlap entrik: {arlap.Count}");
            //(2)osszes pogacsa ara
            double tempPog = 0;
            foreach (var item in arlap)
            {
                if(item is Pogacsa)
                {
                    tempPog += item.MennyibeKerul();
                }
            }
            Console.WriteLine(tempPog);
            //(3)hany habos es nem habos kave van
            int habos = 0;
            int nHabos = 0;
            foreach (var item in arlap)
            {
                if (item is Kave) {
                    Kave tempKave = (Kave)item;
                        if (tempKave.HabosE) habos++; else nHabos++;
                }
            }
            Console.WriteLine($"hab:{habos} nohab:{nHabos}");
            //(4)kave vagy pogacsa hozza adasa a listahoz
            bool isKave = false;
            Console.Write("Kave vagy Pogacsat szeretne hozza adni?[0=Kave 1=Pogacsa]:");
            isKave = Console.ReadLine() == "0" ? true : false;
            bool isKaveHabos = false;
            int pogacsaAmnt, defaultPrice;
            if (isKave)
            {
                Console.Write("Habos a kave?[0=Nem 1=Igen]:");
                isKaveHabos = Console.ReadLine() == "0" ? false : true;
                arlap.Add(new Kave(isKaveHabos));
            }
            else
            {
                Console.Write("Hany darab?[szam]:");
                pogacsaAmnt = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Milyen alapar?[szam]:");
                defaultPrice = int.Parse(Console.ReadLine()!);
                arlap.Add(new Pogacsa(pogacsaAmnt, defaultPrice));
            }
            //(5)legdragabb pogacsa arlap entry
            double pogacsaExpensive = 0;

            foreach (var item in arlap)
            {
                if (item is Pogacsa)
                {
                    pogacsaExpensive = item.MennyibeKerul() > pogacsaExpensive ? item.MennyibeKerul() : pogacsaExpensive;
                }
            }

            int pogacsaIndex = arlap.FindIndex(p => p.MennyibeKerul() == pogacsaExpensive);

            Console.WriteLine(arlap[pogacsaIndex].ToString());
            //(6)pogacsak osszes erteke
            double sumOfPogacsa = 0;
            foreach (var item in arlap)
            {
                if (item is Pogacsa)
                {
                    sumOfPogacsa += item.MennyibeKerul();
                }
            }
            Console.WriteLine($"Az pogacsak osszerteke: {sumOfPogacsa}Ft");
            //(7)kavek osszes erteke
            double sumOfKave = 0;
            foreach (var item in arlap)
            {
                if (item is Kave)
                {
                    sumOfKave += item.MennyibeKerul();
                }
            }
            Console.WriteLine($"Az kavek osszerteke: {sumOfKave}Ft");
            //(8)atlag ar
            double sumOfShit = 0;
            foreach (var item in arlap) sumOfShit += item.MennyibeKerul();
            Console.WriteLine($"Az arlap atlag erteke: {(sumOfShit / arlap.Count).ToString("N0")}Ft");
            //(9)ar szerint sorba rendezes
            var sortedArlap = arlap.OrderBy(item => item.MennyibeKerul()).ToList();
            foreach (var item in sortedArlap) Console.WriteLine(item);
            //(10)mentes fajlba
            using (StreamWriter sw = new("PeksegNew.txt"))
            {
                foreach (var item in sortedArlap)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
    }
}