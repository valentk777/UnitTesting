using System.Diagnostics.Metrics;

namespace PrimeNumberCalculator.Files
{
    public class FileService : IFileService
    {
        public string PropertyForTesting { get; set; }

        public FileService()
        {
            Console.WriteLine("FileService");
        }

        public int GetNumber(string fileName)
        {
            ThrowIfFileNotExist(fileName);

            var fileText = File.ReadAllText(fileName);

            if (int.TryParse(fileText, out var fileContent))
            {
                return fileContent;
            }

            throw new ConversionIssuesException();
        }

        public void SaveNumber(string fileName, int number, bool answer)
        {
            LogIfFileExist(fileName);

            File.WriteAllText(fileName, $"{number} - {answer}");
        }

        private static void LogIfFileExist(string fileName)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine($"File already exist: {fileName}");
            }
        }

        private static void ThrowIfFileNotExist(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
        }
    }
}
