namespace PrimeNumberCalculator.Files
{
    interface IFileService
    {
        public int GetNumber(string fileName);
        public void SaveNumber(string fileName, bool answer);
    }
}
