using Kata.Domain;
namespace Kata.UnitTests
{
    /// <summary>
    /// The goal of this exercise is to convert a string to a new string where each character 
    /// in the new string is "(" if that character appears only once in the original string, or ")" 
    /// if that character appears more than once in the original string. Ignore capitalization 
    /// when determining if a character is a duplicate.
    /// Examples
    ///    "din"      =>  "((("
    ///    "recede"   =>  "()()()"
    ///    "Success"  =>  ")())())"
    ///    "(( @"     =>  "))((" 
    /// Notes
    /// Assertion messages may be unclear about what they display in some languages. 
    /// If you read "...It Should encode XXX", the "XXX" is the expected result, not the input!
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