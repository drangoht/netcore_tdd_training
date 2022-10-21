using Kata.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kata.AcceptanceTests;

public static class ApiHelpers
{
    public static async Task<CamelCaseResponse> CamelCase(this HttpClient client, string val)
    {
        var result = await client.GetAsync($"api/Kata/to_camel_case/{val}");
        var body = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<CamelCaseResponse>(body, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public static async Task<DuplicateEncodeResponse> DuplicateEncode(this HttpClient client, string val)
    {
        var result = await client.GetAsync($"api/Kata/duplicate_encode/{val}");
        var body = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<DuplicateEncodeResponse>(body, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public static async Task<NarcissisticResponse> Narcissistice(this HttpClient client, int val)
    {
        var result = await client.GetAsync($"api/Kata/narcissistic/{val}");
        var body = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<NarcissisticResponse>(body, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public static async Task<HttpResponseMessage> GetIndex(this HttpClient client)
    {
        return await client.GetAsync("/api/Kata");
    }
}