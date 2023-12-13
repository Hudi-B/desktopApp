using NUnit.Framework;
using System;


namespace Tests
{
    [TestFixture]
    public class DivisorAnalysisTests
    {
        [TestCase(7, 1)]
        [TestCase(8, 2)]
        [TestCase(10, 0)]
        public void AnalyzeDivisorsMajorityTest(long input, long output)
        {
            DivisorAnalysis dA = new DivisorAnalysis();

            Assert.That(output, Is.EqualTo(dA.AnalyzeDivisorsMajority(input)));
        }
    }
}
