using System.Reflection;
using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;

namespace PrimeNumberCalculator
{
    public class PrimeNumberCalculator
    {
        private readonly IFileService _fileService;
        private readonly IPrimeService _primeService;
        private string BasePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public PrimeNumberCalculator(IFileService fileService, IPrimeService primeService)
        {
            _fileService = fileService;
            _primeService = primeService;
        }

        public void Run(string file_path = "number.txt")
        {
            var number = _fileService.GetNumber(Path.Join(BasePath, file_path));

            // only for testing
            if (number < 50)
            {
                return;
            }

            var result = _primeService.IsPrime(number);
            _fileService.SaveNumber(Path.Join(BasePath, "numberResult.txt"), number, result);
        }
    }
}
