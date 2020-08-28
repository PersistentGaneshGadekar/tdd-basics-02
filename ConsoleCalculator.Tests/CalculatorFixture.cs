using System;
using Xunit;
using ConsoleCalculator;
namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Theory]
        [InlineData(2,2,"+")]
        public void CalculateAddition(double a, double b, string opration)
        {
            double expected = 4.0;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(-2, -2, "+")]
        public void CalculateAdditionWithNigative(double a, double b, string opration)
        {
            double expected = -4.0;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(-2, 2, "+")]
        public void CalculateAdditionWithOddSign(double a, double b, string opration)
        {
            double expected =  0;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 2, "-")]
        public void CalculateSub(double a, double b, string opration)
        {
            double expected = 0;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(-2, 2, "-")]
        public void CalculateSubWithOddSign(double a, double b, string opration)
        {
            double expected = -4;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2, -2, "-")]
        public void CalculateSubWithNigative(double a, double b, string opration)
        {
            double expected = 0;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 2, "/")]
        public void CalculateDiv(double a, double b, string opration)
        {
            double expected = 1;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(2, 0, "/")]
        public void CalculateDivByZero(double a, double b, string opration)
        {
            double expected = 0;
            double actual = new Calculator().Calculate(a, b, opration);

            Assert.Equal(expected, actual);
        }
    }
}
