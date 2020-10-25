using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Client.Services;
using Model.Services;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
                options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
            });

            builder.Services
                .AddSingleton<IGameApiService, GameApiService>()
                .AddTransient<IGameKeyFactory, GameKeyFactory>()
                .AddSingleton<IGameStateService, GameStateService>();

            ////builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IGameApiService, GameApiService>()
                .ConfigureHttpClient(o => {
                    o.BaseAddress = new Uri(builder.Configuration["ApiRootUri"]);
                });

            await builder.Build().RunAsync();
        }
    }
}
