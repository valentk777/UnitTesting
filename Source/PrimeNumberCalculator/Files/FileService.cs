namespace PrimeNumberCalculator.Files
{
    public class FileService : IFileService
    {
        public int GetNumber(string fileName)
        {
            CheckIfFIleExist(fileName);

            var fileText = File.ReadAllText(fileName);

            if (int.TryParse(fileText, out var fileContent))
            {
                return fileContent;
            }

            throw new ConversionIssuesException();
        }

        // TODO: Write method to save number to file.
        // TODO: Create new file based on file name and store the answer there
        // TODO: Check if file exist and throw exception if not exist
        // TODO: Write tests for that method
        public void SaveNumber(string fileName, bool answer)
        {
            CheckIfFIleExist(fileName);

            throw new NotImplementedException();
        }

        private static void CheckIfFIleExist(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
        }
    }
}
