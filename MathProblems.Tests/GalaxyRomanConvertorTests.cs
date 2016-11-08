using System;
using MathProblems.Galaxy;
using NUnit.Framework;

namespace MathProblems.Tests
{
    [TestFixture, Category("RomanConvert")]
    public class RomanConvertorTests
    {
        private RomanValueCalculator _valueCalculator;

        [SetUp]
        public void Initialize()
        {
            _valueCalculator = new RomanValueCalculator();
        }

        [Test]
        public void DoNothing()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void IShouldReturnOne()
        {
            var number = _valueCalculator.Convert("I");
            Assert.AreEqual(number, 1);
        }

        [Test]
        public void IIShouldReturnTwo()
        {
            var number = _valueCalculator.Convert("II");
            Assert.AreEqual(2, number);
        }

        [Test]
        public void IIIShouldReturnThree()
        {
            var number = _valueCalculator.Convert("III");
            Assert.AreEqual(3, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IIIIShouldThrowInvalidNumberException()
        {
            var number = _valueCalculator.Convert("IIII");
        }

        [Test]
        public void VShouldReturnFive()
        {
            var number = _valueCalculator.Convert("V");
            Assert.AreEqual(5, number);
        }

        [Test]
        public void VIShouldReturnSix()
        {
            var number = _valueCalculator.Convert("VI");
            Assert.AreEqual(6, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VIIIIShouldThrowInvalidNumberException()
        {
            var number = _valueCalculator.Convert("VIIII");
        }

        [Test]
        public void IVShouldReturnFour()
        {
            var number = _valueCalculator.Convert("IV");
            Assert.AreEqual(4, number);
        }

        [Test]
        public void IXShouldReturnNine()
        {
            var number = _valueCalculator.Convert("IX");
            Assert.AreEqual(9, number);
        }

        [Test]
        public void XIXShouldReturnNineteen()
        {
            var number = _valueCalculator.Convert("XIX");
            Assert.AreEqual(19, number);
        }

        [Test]
        public void XXIVShouldReturnTwentyFour()
        {
            var number = _valueCalculator.Convert("XXIV");
            Assert.AreEqual(24, number);
        }

        [Test]
        public void MCMIIIShouldReturn1903()
        {
            var number = _valueCalculator.Convert("MCMIII");
            Assert.AreEqual(1903, number);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotContainMoreThanOneD()
        {
            var number = _valueCalculator.Convert("DD");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotContainMoreThanOneL()
        {
            var number = _valueCalculator.Convert("LL");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotContainMoreThanOneV()
        {
            var number = _valueCalculator.Convert("VIV");
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ILShouldThrowException()
        {
            var number = _valueCalculator.Convert("IL");
        }

    }


    [TestFixture]
    public class CurrencyConvertorShould
    {
        private CurrencyConvertor _currencyConvertor;

        [SetUp]
        public void Initialize()
        {
            _currencyConvertor = new CurrencyConvertor();
        }

        [Test]
        public void EvaluateTheIsExpression()
        {
            _currencyConvertor.Evaluate("glob is I");

            Assert.AreEqual(_currencyConvertor.CurrencyTable[RomanChart.I], "glob");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionIfInvalidRomanCharacterSpecified()
        {
            _currencyConvertor.Evaluate("glob is K");
           
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionIfExpressionDoesNotContainIsOperator()
        {
            _currencyConvertor.Evaluate("glob yo I");
        }

    }
}
