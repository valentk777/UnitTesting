using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;

namespace PrimeNumberCalculator
{
    public class PrimeNumberCalculator
    {
        // TODO: Add depencency injection for this class.
        // TODO: Clean run function to work with services provided by Dependency injection.
        // TODO: Fix file paths in method Run().
        public PrimeNumberCalculator()
        { 
        }

        public void Run()
        {
            var fileService = new FileService();
            var primeService = new PrimeService();

            var number = fileService.GetNumber("");
            var result = primeService.IsPrime(number);
            fileService.SaveNumber("", result);
        }
    }
}
