using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;

namespace PrimeNumberCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Re-write to use depencenty injection
            var fileServices = new FileService();
            var primeServices = new PrimeService();

            var primeNumberCalculator = new PrimeNumberCalculator(fileServices, primeServices);
            primeNumberCalculator.Run();
        }
    }
}