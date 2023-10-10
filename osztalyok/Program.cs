using System.Globalization;

namespace osztalyok
{
    class Tanulo
    {
        double atlag;
        public readonly int kor;
        string nev;
        string osztaly;
        static string iskola = "Iskola";
        static int darab;

        public double Atlag { get => atlag; set => atlag = (value > 1.0 && value < 5.0) ? value : 0; }
        public string Osztaly { get => osztaly; set => osztaly = value; }
        public int Darab { get => darab; set => darab = value; }
        public static string Iskola { get => iskola; }

        public Tanulo(double atlag, string nev, string osztaly)
        {
            Random rnd = new Random();
            this.atlag = atlag;
            this.nev = nev;
            this.osztaly = osztaly;

            this.kor = rnd.Next(14, 19);
            this.Darab++;
        }

        public string GetNev()
        {
            return this.nev;
        }
        public string SetNev(string nev)
        {
            return this.nev = nev;
        }
        public override string ToString()
        {
            return $"Név: {this.nev}, Kor: {this.kor}év, Osztály: {this.osztaly}, Átlaga: {this.atlag}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<string> vezetek = new List<string>();
            List<string> fiu = new List<string>();
            List<string> lany = new List<string>();
            List<Tanulo> tanulok = new List<Tanulo>();

            foreach (var line in File.ReadAllLines("vezeteknevek.txt")) vezetek.Add(line);
            foreach (var line in File.ReadAllLines("ferfi.txt")) fiu.Add(line);
            foreach (var line in File.ReadAllLines("noi.txt")) lany.Add(line);

            string abc = "ABCDE";

            for (int i = 0; i <= 9; i++)
            {
                string nev = $"{vezetek[rnd.Next(0, vezetek.Count)]} {fiu[rnd.Next(0, fiu.Count)]}";
                double atlag = rnd.Next(1, 5) + Math.Round(rnd.NextDouble(), 1);
                string osztaly = $"{rnd.Next(9, 14)} {abc[rnd.Next(abc.Length)]}";

                tanulok.Add(new Tanulo(atlag, nev, osztaly));
            }
            for (int i = 0; i <= 9; i++)
            {
                string nev = $"{vezetek[rnd.Next(0, vezetek.Count)]} {lany[rnd.Next(0, lany.Count)]}";
                double atlag = rnd.Next(1, 5) + Math.Round(rnd.NextDouble(), 1);
                string osztaly = $"{rnd.Next(9, 14)} {abc[rnd.Next(abc.Length)]}";

                tanulok.Add(new Tanulo(atlag, nev, osztaly));
            }

            //3.feladat
            Console.WriteLine("\n3.feladat\n");

            foreach (var item in tanulok)
            {
                Console.WriteLine(item.ToString());
            }

            //4.feladat
            Console.WriteLine("\n4.feladat\n");

            int indexOfSmartest = tanulok.FindIndex(p => p.Atlag == tanulok.Max(x => x.Atlag));

            Console.WriteLine(tanulok[indexOfSmartest].ToString());

            //5.feldat
            Console.WriteLine("\n5.feladat\n");

            int overSixteen = 0;

            foreach (var item in tanulok) 
            {
                if (item.kor >= 16)
                {
                    overSixteen++;
                }
            }

            Console.WriteLine($"{overSixteen} nem tankoteles");

            //6.feladat
            Console.WriteLine("\n6.feladat\n");

            int[] ertekeles = { 0, 0, 0, 0, 0 };

            foreach (var item in tanulok)
            {
                switch (item.Atlag)
                {
                    case double n when (n < 2):
                        ertekeles[0] += 1;
                        break;
                    case double n when (n > 2 && n < 3):
                        ertekeles[1] += 1;
                        break;
                    case double n when (n > 3 && n < 4):
                        ertekeles[2] += 1;
                        break;
                    case double n when (n > 4 && n < 4.5):
                        ertekeles[3] += 1;
                        break;
                    case double n when (n > 4.5):
                        ertekeles[4] += 1;
                        break;
                }
            }

            Console.WriteLine($"rossz: {ertekeles[0]}\ngyenge: {ertekeles[1]}\nkozepes: {ertekeles[2]}\njo: {ertekeles[3]}\njeles: {ertekeles[4]}");
        }
    }
}