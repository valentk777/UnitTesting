using System.Reflection;
using PrimeNumberCalculator.Files;
using Xunit;

namespace Prime.UnitTests.Services
{
    public class FileServiceTests
    {
        private string BasePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Fact]
        public void GetNumber_GetNumber1000FromAFile_ReturnTrue()
        {
            // Arrange
            var fileService = new FileService();

            // Act
            int result = fileService.GetNumber(Path.Join(BasePath, "tests-number.txt"));

            // Assert
            Assert.Equal(1000, result);
        }

        [Fact]
        public void GetNumber_GetNumberFromEmptyFile_ThrowException()
        {
            // Arrange
            var fileService = new FileService();

            // Act
            // Assert
            Assert.Throws<ConversionIssuesException>(() => fileService.GetNumber(Path.Join(BasePath, "tests-empty-file.txt")));
        }

        [Fact]
        public void GetNumber_PassInvalidFileName_ThrowException()
        {
            // Arrange
            var fileService = new FileService();
            var nonExistingFilePath = Guid.NewGuid().ToString();

            // Act
            // Assert
            Assert.Throws<FileNotFoundException>(() => fileService.GetNumber(nonExistingFilePath));
        }

        [Fact]
        public void SaveNumber_FileIsCreated_ResultTrue()
        {
            // Arrange
            var fileService = new FileService();
            var fileContent = true;

            // Act
            fileService.SaveNumber(Path.Join(BasePath, "tests-create-file.txt"), 7, fileContent);

            // Assert
            Assert.True(File.Exists(Path.Join(BasePath, "tests-create-file.txt")));
        }
    }
}