using FluentAssertions.Equivalency;
using Kata.Domain;
using System.ComponentModel;
using System;
namespace Kata.UnitTests
{
    /// <summary>
    /// Write an algorithm that will identify valid IPv4 addresses in dot-decimal format.IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.

    /// Valid inputs examples:
    /// Examples of valid inputs:
    /// 1.2.3.4
    /// 123.45.67.89
    /// Invalid input examples:
    /// 1.2.3
    /// 1.2.3.4.5
    /// 123.456.78.90
    /// 123.045.067.089
    /// Notes:
    /// Leading zeros (e.g. 01.02.03.04) are considered invalid
    /// Inputs are guaranteed to be a single string
    /// </summary>
    public class IsValidIPShould
    {

        [Theory]
        [InlineData("0.0.0.0", true)]
        [InlineData("12.255.56.1", true)]
        [InlineData("137.255.156.100", true)]
        [InlineData("", false)]
        [InlineData("abc.def.ghi.jkl", false)]
        [InlineData("123.456.789.0", false)]
        [InlineData("12.34.56", false)]
        [InlineData("12.34.56.00", false)]
        [InlineData("12.34.56.7.8", false)]
        [InlineData("12.34.256.78", false)]
        [InlineData("1234.34.56", false)]
        [InlineData("pr12.34.56.78", false)]
        [InlineData("12.34.56.78sf", false)]
        [InlineData("12.34.56 .1", false)]
        [InlineData("12.34.56.-1\"", false)]
        [InlineData("123.045.067.089", false)]
        public void ReturnTrueIfIPIsInCorrectFormat(string adrIP,bool result)
        {
            var katas = new Katas();
            Assert.Equal(result, katas.IsValidIP(adrIP));
        }
    }
}