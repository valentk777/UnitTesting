using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace PrimeNumberCalculator
{
    public class PrimeNumberCalculator
    {
        private IFileService _fileService;
        private IPrimeService _primeService;
        private string BasePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        // TODO: Add depencency injection for this class. + (mb)
        // TODO: Clean run function to work with services provided by Dependency injection. + (mb)
        // TODO: Fix file paths in method Run(). +
        public PrimeNumberCalculator(IFileService fileService, IPrimeService primeService)
        {
            _fileService = fileService;
            _primeService = primeService;
        }

        // I don't really know how we should test it, if it just run other tested methods
        public void Run()
        {
            var number = _fileService.GetNumber(Path.Join(BasePath, "number.txt"));
            var result = _primeService.IsPrime(number);
            _fileService.SaveNumber(Path.Join(BasePath, "numberResult.txt"), result);
        }
    }
}
