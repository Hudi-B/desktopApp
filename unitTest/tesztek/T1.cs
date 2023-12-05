using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitTest.tesztek
{
    [TestFixture]
    internal class T1
    {
        [Test]
        [TestCase(6)]
        [TestCase(5)]
        public void MatekOsszeg(int i1)
        {
            Matek m = new Matek(2);
            Assert.That(i1, Is.EqualTo(m.Osszeg(4)));
        }
        [Test]
        public void MatekEloszt()
        {
            Matek m = new Matek(3);
            //Assert.That(1, Is.EqualTo(m.Eloszt(3));
            Assert.Throws<FormatException>(
                () =>
                {
                    m.Eloszt(3);
                }
            );
        }
    }
}
