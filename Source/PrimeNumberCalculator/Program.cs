using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;

namespace PrimeNumberCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host
                .CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                    {
                        services.AddTransient<PrimeNumberCalculator>();
                        services.AddSingleton<FileService>();
                        services.AddSingleton<IPrimeService, PrimeService>();
                        services.AddSingleton<IPrimeService, PrimeServiceSlow>();
                        // Note: note that scoped option exist.
                        // services.AddScoped<PrimeNumberCalculator>();
                    })
                .Build();

            var primeNumberCalculator = host.Services.GetRequiredService<PrimeNumberCalculator>();
            primeNumberCalculator.Run();
        }
    }
}