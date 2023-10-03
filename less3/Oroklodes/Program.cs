using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oroklodes14C
{
    interface IPelda
    {
        void Kiir();
    }
    interface Ipelda1
    {
        void Kiir();
    }
    abstract class Alakzat
    {
        public abstract void Rajzol();
    }
    class Negyzet : Alakzat
    {
        public override void Rajzol()
        {
            Console.WriteLine("Ez egy négyzet");
        }
    }
    class Allat : IPelda, Ipelda1
    {
        protected string hely;
        protected string beszed;

        public Allat(string hely)
        {

            this.hely = hely;
        }

        public override string ToString()
        {
            return $"Az állat azt mondi hogy: {beszed}";
        }

        public virtual void Beszel()
        {
            beszed = "WAAAA WAAA WAAAA";
        }
        public string MitMond() { return beszed; }

        public void Kiir()
        {
            Console.WriteLine("Allat");
        }
        void Ipelda1.Kiir()
        {
            Console.WriteLine("Ipelda1");
        }
    }
    class Kutya : Allat
    {
        protected string gazdi;

        public Kutya(string hely, string gazdi) : base(hely)
        {
            this.gazdi = gazdi;
        }

        public override void Beszel()
        {
            beszed="ÉC";
        }
        public override string ToString()
        {
            return $"A kutya azt mondi hogy: {beszed}";
        }
    }
    class Macska : Allat
    {
        public Macska(string hely) : base(hely)
        {
        }

        public override void Beszel()
        {
            beszed = "NAGYKANIZSAAAAAA";
        }

        public override string ToString()
        {
            return $"A macska azt mondi hogy: {beszed}";
        }
    }
    class Kiskutya : Kutya
    {
        public Kiskutya(string hely, string gazdi) : base(hely, gazdi)
        {
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Allat a = new Allat("Miskolc");
            Kutya k = new Kutya("Érd", "Géza");
            Macska m = new Macska("Nagykanizsa");
            Allat KutyaAllat = new Kutya("Jenő","asd");

            Negyzet n = new Negyzet();


            a.Beszel(); a.Kiir();
            IPelda ip = a;
            ip.Kiir();
            k.Beszel();
            m.Beszel();
            KutyaAllat.Beszel();


            Console.WriteLine(a);//a.ToString();
            Console.WriteLine(k);
            Console.WriteLine(m);
            n.Rajzol();
            
            Console.ReadKey();
        }
    }
}