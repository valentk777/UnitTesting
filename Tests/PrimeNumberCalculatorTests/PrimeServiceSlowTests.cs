using PrimeNumberCalculator.Primes;
using Xunit;

namespace Prime.UnitTests.Services
{
    public class PrimeServiceTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_InputEdgeCasesNotPrime_ReturnFalse(int number)
        {
            // Arrange
            var primeService = new PrimeService();
            
            // Act
            bool result = primeService.IsPrime(number);

            // Assert
            Assert.False(result, $"{number} should not be prime");
        }

        [Theory]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(10000002)]
        public void IsPrime_InputNotPrimeNumber_ReturnFalse(int number)
        {
            // Arrange
            var primeService = new PrimeService();

            // Act
            bool result = primeService.IsPrime(number);

            // Assert
            Assert.False(result, $"{number} should not be prime");
        }

        [Fact]
        public void IsPrime_InputNotPrimeNumber_ThrowsException()
        {
            // Arrange
            var primeService = new PrimeService();

            // Act
            bool result = primeService.IsPrime(null);

            // Assert
            Assert.False(result);
        }
    }
}