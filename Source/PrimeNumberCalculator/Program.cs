namespace PrimeNumberCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Re-write to use depencenty injection
            var primeNumberCalculator = new PrimeNumberCalculator();
            primeNumberCalculator.Run();
        }
    }
}