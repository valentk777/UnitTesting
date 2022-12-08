namespace PrimeNumberCalculator.Files
{
    public interface IFileService
    {
        public string PropertyForTesting { get; set; }

        public int GetNumber(string fileName);
        public void SaveNumber(string fileName, int number, bool answer);
    }
}
