using System.Reflection;
using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;
using PrimeNumberCalculator;
using Xunit;


namespace PrimeNumberCalculator.Tests
{
    public class PrimeNumberCalculatorTests
    {
        private string BasePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Fact]
        public void Run_StartTheProgramm_AllMethodsAreSuccesfull() 
        {
            // Arrange
            var fileService = new FileService();
            var primeService = new PrimeService();
            var primeNumberCalculator = new PrimeNumberCalculator(fileService, primeService);

            var fileContent = false;

            // Act
            primeNumberCalculator.Run();

            // Assert
            Assert.False(primeService.IsPrime(4));
            Assert.Equal(4, fileService.GetNumber(Path.Join(BasePath, "tests-number.txt")));
            Assert.True(File.Exists(Path.Join(BasePath, "tests-create-file.txt")));
        }
    }
}
