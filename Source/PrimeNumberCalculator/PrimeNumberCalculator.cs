using System.Reflection;
using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;

namespace PrimeNumberCalculator
{
    public class PrimeNumberCalculator
    {
        private FileService _fileService;
        private IPrimeService _primeService;
        private string BasePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // TODO: Add dependency injection for this class.
        // TODO: Clean run function to work with services provided by Dependency injection.
        // TODO: Fix file paths in method Run().
        public PrimeNumberCalculator(FileService fileService, IPrimeService primeService)
        {
            _fileService = fileService;
            _primeService = primeService;

            Console.WriteLine("PrimeNumberCalculator");
        }

        public void Run()
        {
            _fileService.PropertyForTesting = "test";
            var number = _fileService.GetNumber(Path.Join(BasePath, "number.txt"));
            var result = _primeService.IsPrime(number);
            _fileService.SaveNumber(Path.Join(BasePath, "numberResult.txt"), number, result);
        }
    }
}
