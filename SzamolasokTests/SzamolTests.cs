using Microsoft.VisualStudio.TestTools.UnitTesting;
using Szamolasok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamolasok.Tests
{
    [TestClass()]
    public class SzamolTests
    {
        [TestMethod()]
        public void KivonasTest()
        {
            Szamol sz = new Szamol(6);
            Assert.AreEqual(4, sz.Kivonas(2));
        }

        [TestMethod()]
        public void SzorzasTest()
        {
            Szamol sz = new Szamol(6);
            Assert.AreEqual(12, sz.Szorzas(2));
        }

        [TestMethod()]
        public void GyokTest()
        {
            Szamol sz = new Szamol(6);
            Assert.AreEqual(36, sz.Gyok(2));
        }

        [TestMethod()]
        public void SzerkezhetoEaHaromszogTest()
        {
            Szamol sz = new Szamol(6);
            Assert.AreEqual(true, sz.SzerkezhetoEaHaromszog(20, 20, 30));
        }
    }
}