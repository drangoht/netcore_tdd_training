using FluentAssertions.Equivalency;
using Kata.Domain;
using System.Numerics;

namespace Kata.UnitTests
{
    /// <summary>
    ///    Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.
    /// Notes:
    /// Only lower case letters will be used(a-z). No punctuation or digits will be included.
    /// Performance needs to be considered.
    /// </summary>
    public class AddBigNumberShould
    {

        [Theory]
        [InlineData("91", "19", "110")]
        [InlineData("987654322", "123456789", "1111111111")]
        [InlineData("999999999", "1", "1000000000")]
        [InlineData("999999999999999999999", "1", "1000000000000000000000")]
        [InlineData("1234", "123", "1357")]
        public void ReturnGoodResultWhenAdding(string strnum1, string strnum2, string result)
        {
            var katas = new Katas();
            Assert.Equal(result, katas.AddBigNumber(strnum1, strnum2));
        }
    }
}