using StringCalculator2;
using System;
using Xunit;

namespace CalculatorTest
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = Calculator.SumString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("25", 30)]
        [InlineData("10", 10)]
        [InlineData("0", 0)]
        public void SingleNumberReturnsValue(string input, int expectedResult)
        {
            int result = Calculator.SumString(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("29,11", 40)]
        [InlineData("0,10", 10)]
        [InlineData("5,3", 8)]
        public void TwoNumbersCommaDelimetedReturnsTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("29\n11", 40)]
        [InlineData("0\n10", 10)]
        [InlineData("6\n3", 9)]
        public void TwoNumbersNewLineDelimetedReturnsTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("29\n11,12", 52)]
        [InlineData("0\n10\n5", 15)]
        [InlineData("10,5\n3", 18)]
        public void ThreeNumbersDelimetedEitherWayReturnsTheSum(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("-7,12")]
        [InlineData("12\n-7")]
        public void NegativeNumbersThrowAnException(string s)
        {
           _ = Assert.Throws<ArgumentException>(() => Calculator.SumString(s));
        }

        [Theory]
        [InlineData("29\n11,1111", 40)]
        [InlineData("0\n10\n65536", 10)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void NumbersGreaterThan1000AreIgnored(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//#\n29#11", 40)]
        [InlineData("//$\n29$11", 40)]
        [InlineData("//$\n29$11,10\n10", 60)]
        public void SingleCharDelimeter(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }

        [Theory]
        [InlineData("//[###]\n29###11", 40)]
        [InlineData("//[$$$]\n29$$$11", 40)]
        [InlineData("//[$:]\n29$:11,10", 50)]
        public void MultiCharDelimeter(string s, int x)
        {
            int res = Calculator.SumString(s);
            Assert.Equal(x, res);
        }
    }
}
