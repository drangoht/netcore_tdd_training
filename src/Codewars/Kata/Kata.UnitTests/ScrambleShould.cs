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
    public class ScrambleShould
    {

        [Theory]
        [InlineData("rkqodlw", "world", true)]
        [InlineData("cedewaraaossoqqyt", "codewars",true)]
        [InlineData("katas", "steak",false)]
        [InlineData("scriptjavx", "javascript",false)]
        [InlineData("scriptingjava", "javascript",true)]
        [InlineData("scriptsjava", "javascripts",true)]
        [InlineData("javscripts", "javascript",false)]
        [InlineData("aabbcamaomsccdd", "commas",true)]
        [InlineData("commas", "commas",true)]
        [InlineData("sammoc", "commas",true)]
        public void ReturnTrueIfAllLettersFound(string str, string strToSearch, bool result)
        {
            var katas = new Katas();
            Assert.Equal(result, katas.Scramble(str, strToSearch));
        }
    }
}