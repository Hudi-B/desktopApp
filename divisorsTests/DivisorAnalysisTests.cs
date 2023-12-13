using divisors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class DivisorAnalysisTests
    {
        [DataTestMethod]
        [DataRow(7, 1)]
        [DataRow(8, 2)]
        [DataRow(10, 0)]
        public void AnalyzeDivisorsMajorityTest(long input, long output)
        {
            DivisorAnalysis dA = new DivisorAnalysis();

            Assert.AreEqual(output, dA.AnalyzeDivisorsMajority(input));
        }
    }
}