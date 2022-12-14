namespace PrimeNumberCalculator.Files
{
    public interface IFileService
    {
        public int GetNumber(string fileName);
        public void SaveNumber(string fileName, int number, bool answer);
    }
}
