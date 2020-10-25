using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Client.Services
{
    public class GameApiService : IGameApiService
    {
        private readonly HttpClient _httpClient;

        public GameApiService(
            HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetHelloWorld(CancellationToken cancellationToken)
        {
            return await _httpClient.GetStringAsync("HelloWorldFunction");
        }
    }
}
