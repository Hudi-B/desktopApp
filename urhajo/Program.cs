using System.IO;

namespace urhajo
{
    interface IUrhajo
    {
        bool LegyorsuljaE(IUrhajo obj);
        double MilyenGyors();
    }
    interface Ihiperhajtomu
    {
        void HiperUgras();
    }
    abstract class LazadoGep : IUrhajo
    {
        private double sebesseg;
        private bool meghibasodhatE;

        public double MilyenGyors()
        {
            return sebesseg;
        }
        public bool LegyorsuljaE(IUrhajo obj)
        {
            if (obj is MilleniumFalcon) return false;
            else if (obj.MilyenGyors() < sebesseg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public LazadoGep(double sebesseg, bool meghibasodhatE)
        {
            this.sebesseg = sebesseg;
            this.meghibasodhatE = meghibasodhatE;
        }

        public override string ToString()
        {
            return $"A lazadogep sebessege: {sebesseg}, {(meghibasodhatE ? "meghibasodhat" : "nem hibasodhat meg")}";
        }

        public abstract bool ElkapjaAVonosugarat();
    }
    class XWing : LazadoGep, Ihiperhajtomu
    {
        private double sebesseg = 150;
        private bool meghibasodhatE = true;
        public XWing(double sebesseg, bool meghibasodhatE) : base(sebesseg, meghibasodhatE) { }

        public override bool ElkapjaAVonosugarat()
        {
            if (meghibasodhatE && sebesseg < 1000) return true;
            else return false;
        }

        public void HiperUgras()
        {
            Random rnd = new();
            this.sebesseg += rnd.Next(0, 100);
        }

        public override string ToString()
        {
            return base.ToString() + ", Tipusa: X-Wing";
        }
    }
    class MilleniumFalcon : IUrhajo, Ihiperhajtomu
    {
        double tapasztalat;
        public MilleniumFalcon()
        {
            this.tapasztalat = 100;
        }

        public void HiperUgras()
        {
            tapasztalat += 500;
        }

        public bool LegyorsuljaE(IUrhajo obj)
        {
            if (obj.MilyenGyors() < (tapasztalat * 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double MilyenGyors()
        {
            return this.tapasztalat * 2;
        }

        public override string ToString()
        {
            return $"A lazadogep sebessege: {tapasztalat * 2}, Tapasztalat: {tapasztalat}, nem hibasodhat meg, Tipusa: Millenium Falcon";
        }
    }
    internal class StarWars
    {
        static List<IUrhajo> urhajokL = new();
        public static void Urhajok(string path)
        {
            string[] read = File.ReadAllLines(path);
            for (int i = 0; i < read.Length; i++)
            {
                string[] x = read[i].Split(' ');
                if (x[0] == "MilleniumFalcon")
                {
                    urhajokL.Add(new MilleniumFalcon());
                    for (int j = 0; j < int.Parse(x[1]); j++)
                    {
                        ((MilleniumFalcon)urhajokL[i]).HiperUgras();
                    }
                }
                else
                {
                    urhajokL.Add(new XWing(int.Parse(x[1]), false));
                    for (int j = 0; j < int.Parse(x[1]); j++)
                    {
                        ((XWing)urhajokL[i]).HiperUgras();
                    }
                }
            }
        }
        public static void Hangar()
        {
            foreach (var item in urhajokL)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void Main(string[] args)
        {
            Urhajok("Urhajok.txt");
            Hangar();
        }
    }

}