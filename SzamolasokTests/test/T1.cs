using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szamolasok;

namespace unitTest.tesztek
{
    [TestFixture]
    internal class T1
    {
        [Test]
        [TestCase(4, 2)]
        [TestCase(1, 5)]
        public void KivonasTest(double a, double b)
        {
            Szamol sz = new Szamol(6);
            Assert.That(a, Is.EqualTo(sz.Kivonas(b)));
        }
        [Test]
        [TestCase(12, 2)]
        [TestCase(24, 4)]
        public void SzorzasTest(double a, double b)
        {
            Szamol sz = new Szamol(6);
            Assert.That(a, Is.EqualTo(sz.Szorzas(b)));
        }
        [Test]
        [TestCase(36, 2)]
        [TestCase(1296, 4)]
        public void GyokTest(double a, double b)
        {
            Szamol sz = new Szamol(6);
            Assert.That(a, Is.EqualTo(sz.Gyok(b)));
        }
        [Test]
        [TestCase(true, 20, 20, 30)]
        [TestCase(false, 20, 10, 31)]
        public void SzerkezhetoTest(bool x, double a, double b, double c)
        {
            Szamol sz = new Szamol(6);
            Assert.That(x, Is.EqualTo(sz.SzerkezhetoEaHaromszog(a, b, c)));
        }

        [Test]
        public void SzerkezhetoNullTest()
        {
            Szamol sz = new Szamol(6);
            Assert.Throws<FormatException>(
                () =>
                {
                    sz.SzerkezhetoEaHaromszog(20,20,Convert.ToDouble("b"));
                }
            );
        }
    }
}
