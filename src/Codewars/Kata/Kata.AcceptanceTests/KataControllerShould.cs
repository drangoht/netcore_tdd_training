using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using Kata.AcceptanceTests;

namespace Kata.AcceptanceTests
{
    public class KataControllerShould
    {

        private WebApplicationFactory<Program> testHost;
        private HttpClient client;

        public KataControllerShould()
        {
            testHost = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(_ => { });

            client = testHost.CreateClient();
        }

        [Fact]
        public async Task ReturnSuccessCodeWhenGet()
        {
            // Arrange

            // Act 
            var result = await client.GetIndex();

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Theory]
        [InlineData("theStealthWarrior", "the_stealth_warrior")]
        [InlineData("TheStealthWarrior", "The-Stealth-Warrior")]
        [InlineData("zouBiDa", "zou_bi-da")]
        public async Task ReturnResponseCamelCaseWhenDashOrUnderscoreFound(string expected, string accept)
        {
            // Arrange

            // Act
            var response = await client.CamelCase(accept);
            // Assert

            Assert.Equal(expected, response.Result);
        }

        [Theory]
        [InlineData("(((", "din")]
        [InlineData("()()()", "recede")]
        [InlineData(")())())", "Success")]
        [InlineData("))((", "(( @")]
        public async Task ReturnResponseRightEncodageFromDefinedRule(string expected, string accept)
        {
            var response = await client.DuplicateEncode(accept);
            Assert.Equal(expected, response.Result);
        }


        public static TheoryData<int, bool> DataForTest1 = new TheoryData<int, bool> {
            { 1, true },
            { 371, true }
        };

        [Theory]
        [MemberData(nameof(DataForTest1))]
        public async Task ReturnResponseTrueWhenNumberIsNarcissistic(int number, bool result)
        {
            var response = await client.Narcissistice(number);
            Assert.Equal(result, response.Result);
        }
    }
}