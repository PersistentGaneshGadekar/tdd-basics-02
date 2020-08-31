using System;
using System.Collections.Generic;
using System.Text;
using ConsoleCalculator;
using Xunit;
namespace ConsoleCalculator.Tests
{
   public class InputTests
    {
        [Theory]
        [InlineData("","/",12,0)]
        public void checkDevidbyZeroErrorTest(string pOp, string cOp, double a, double b)
        {
            bool expected = true;
            Operations operations = new Operations();
            bool actual= operations.checkDevideByZeroErr(pOp, cOp, a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", "/", 12, 2)]
        public void checkDevidbyZeroErrorFaliTest(string pOp, string cOp, double a, double b)
        {
            bool expected = false;
            Operations operations = new Operations();
            bool actual = operations.checkDevideByZeroErr(pOp, cOp, a, b);
            Assert.Equal(expected, actual);
        }
    }
}
