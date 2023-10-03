using System.Reflection.Metadata;

namespace oroklesGyakorlas
{
    internal class Program
    {
        class Pont
        {
            public int X;
            public int Y;

            public Pont(int xIn, int yIn)
            {
                X = xIn;
                Y = yIn;
            }
            public Pont() 
            { 
                this.X = 0;
                this.Y = 0;
            }

            public override string ToString()
            {
                return $"x = {X}\ny = {Y}";
            }
        }
        class Kor
        {
            public new Pont Kozeppont;
            public double Sugar;
            public static int AmountOut { get => Amount; }

            private static int Amount = 0;

            public Kor(Pont Kozeppont, double s)
            {
                this.Kozeppont = Kozeppont;
                this.Sugar = s;
                Amount++;
            }
            public Kor(int a, int b, double s)
            {
                Kozeppont = new(a ,b);
                Sugar = s;
                Amount++;
            }
            public Kor()
            {
                Kozeppont = new();
                Sugar = 1;
                Amount++;
            }
            public string Terulet()
            {
                return $"A kor terulete: {Math.PI * Math.Pow(Sugar, 2)}";
            }
            public string Kerulet()
            {
                return $"A kor kerulete: {2 * (Math.PI * Sugar)}";
            }
            public void Eltol(int a, int b)
            {
                Kozeppont.X += a;
                Kozeppont.Y += b;
            }
            public override string ToString()
            {
                return $"A kor kozeppontja: {Kozeppont.ToString()}\nA kor sugara: {Sugar}\nA kor terulete: {this.Terulet()}\nA kor kerulete{this.Kerulet()}";
            }
        }
        static void Main(string[] args)
        {
            Pont D2 = new(5, 12);
        }
    }
}