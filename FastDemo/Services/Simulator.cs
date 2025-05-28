using System.Net.Http;
using System.Net.Http.Json;
using FastDemo.Models;

namespace FastDemo.Services;

public class Simulator
{
    private HttpClient _client;

    public Simulator(HttpClient client)
    {
        _client = client;
    }

    private async Task<string?> Get(string method)
        => (await _client.GetFromJsonAsync<Response>("http://localhost:4444/TransferSimulator/" + method))?.Value;

    public async Task<string?> GetFullName()
        => await Get("phoneNumber");
}
