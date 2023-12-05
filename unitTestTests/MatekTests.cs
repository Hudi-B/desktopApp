using Microsoft.VisualStudio.TestTools.UnitTesting;
using unitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTest.Tests
{
    [TestClass()]
    public class MatekTests
    {
        [TestMethod()]
        public void NegyzetTest()
        {
            Matek m = new Matek(3);
            Assert.AreEqual(9, m.Negyzet());
        }
        [TestMethod()]
        public void OsszegTest()
        {
            Matek m = new Matek(3);
            Assert.AreEqual(9, m.Osszeg(6));
        }
    }
}