using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("unitTestTests")]

namespace unitTest
{
    public class Matek
    {
        int a;

        public Matek(int a)
        {
            this.a = a;
        }

        public int Negyzet()
        {
            return a * a;
        }

        public int Osszeg(int b)
        {
            return a + b;
        }
        public double Eloszt(int b)
        {
            return a / b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
