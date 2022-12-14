using PrimeNumberCalculator.Files;
using PrimeNumberCalculator.Primes;
using Xunit;
using Moq;

namespace PrimeNumberCalculator.Tests
{
    public class PrimeNumberCalculatorTests
    {
        // If you mock actual class, you get runtime exception. Why?
        // MOQ creates an implementation of the mocked type.
        // If the type is an interface, it creates a class that implements the interface.
        // If the type is a class, it creates an inherited class, and the members of that
        // inherited class call the base class. But in order to do that it has to override
        // the members. If a class has members that can't be overridden
        // (they aren't virtual, abstract) then MOQ can't override them to add its own behaviors.
        // Source: https://stackoverflow.com/questions/56905578/moq-non-overridable-members-may-not-be-used-in-setup-verification-expression

        [Fact]
        public void PrimeNumberCalculator_Run_WithLowPrimeNumber()
        {
            // Arrange
            var fileServiceMock = new Mock<IFileService>();
            var primeServiceMock = new Mock<IPrimeService>();
            var numberFromFile = 5;
            var isPrimeNumberAnswer = true;

            fileServiceMock
                .Setup(x => x.GetNumber(It.IsAny<string>()))
                .Returns(numberFromFile);

            fileServiceMock
                .Setup(x => x.SaveNumber(It.IsAny<string>(), numberFromFile, isPrimeNumberAnswer));

            primeServiceMock
                .Setup(x => x.IsPrime(numberFromFile))
                .Returns(isPrimeNumberAnswer);

            var primeNumberCalculator = new PrimeNumberCalculator(fileServiceMock.Object, primeServiceMock.Object);

            // Act
            primeNumberCalculator.Run(It.IsAny<string>());

            // Assert
            fileServiceMock.Verify(x => x.GetNumber(It.IsAny<string>()), Times.Once);
            primeServiceMock.Verify(x => x.IsPrime(It.IsAny<int>()), Times.Never);
            fileServiceMock.Verify(x => x.SaveNumber(It.IsAny<string>(), numberFromFile, isPrimeNumberAnswer), Times.Never);
        }

        [Fact]
        public void PrimeNumberCalculator_Run_WithBigNotPrimeNumber()
        {
            // Arrange
            var fileServiceMock = new Mock<IFileService>();
            var primeServiceMock = new Mock<IPrimeService>();
            var numberFromFile = 52;
            var isPrimeNumberAnswer = false;

            fileServiceMock
                .Setup(x => x.GetNumber(It.IsAny<string>()))
                .Returns(numberFromFile);

            fileServiceMock
                .Setup(x => x.SaveNumber(It.IsAny<string>(), numberFromFile, isPrimeNumberAnswer));

            primeServiceMock
                .Setup(x => x.IsPrime(numberFromFile))
                .Returns(isPrimeNumberAnswer);

            var primeNumberCalculator = new PrimeNumberCalculator(fileServiceMock.Object, primeServiceMock.Object);

            // Act
            primeNumberCalculator.Run(It.IsAny<string>());

            // Assert
            fileServiceMock.Verify(x => x.GetNumber(It.IsAny<string>()), Times.Once);
            primeServiceMock.Verify(x => x.IsPrime(It.IsAny<int>()), Times.Once);
            fileServiceMock.Verify(x => x.SaveNumber(It.IsAny<string>(), numberFromFile, isPrimeNumberAnswer), Times.Once);
        }
    }
}
