using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomVariableCalculator;

namespace RvcTests
{
    [TestClass]
    public class LogicTests
    {
        private TestContext testContextInstance;
        private const double ErrorMargin = 0.00001;

        public TestContext TestContext
        { 
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void CombinationMethodTest()
        {
            Assert.AreEqual(Logic.nCr(5, 3), 10);
            Assert.AreEqual(Logic.nCr(20, 4), 4845);
            Assert.AreEqual(Logic.nCr(24, 8), 735471);
        }

        [TestMethod]
        public void BinomialMethodTest()
        {
            ProbabilityResult result = Logic.BinomialDistributionRV(n:"7", p:"0.54");
            double expectedValue = double.Parse(result.ExpectedValue);
            Assert.AreEqual(result.PmfTable["3"], "0.2467633");
            Assert.IsTrue(Math.Abs(expectedValue - 3.78) < ErrorMargin);
        }
        [TestMethod]
        [ExpectedException(typeof(ProbabilityOutOfBoundException),
            "A probability outside of [0, 1] was inappropriately allowed.")]
        public void OutOfBoundBinomialArgumentTest()
        {
            Logic.BinomialDistributionRV(n: "7", p: "1.35");
        }
        [TestMethod]
        [ExpectedException(typeof(ValueTypeMismatchException), 
            "A string argument given could not be parsed as an integer / float")]
        public void ArgumentTypeMismatchBinomialTest()
        {
            Logic.BinomialDistributionRV(n: "4,", p: "0.2");
        }

        [TestMethod]
        public void PoissonMethodTest()
        {
            var kList = new List<string> { "1", "5", "13" };
            ProbabilityResult result = Logic.PoissonRV(kList, "13", "1");

        }
    }
}
