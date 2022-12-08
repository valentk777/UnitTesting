namespace PrimeNumberCalculator.Primes
{
    public class PrimeServiceSlow : IPrimeService
    {
        public PrimeServiceSlow()
        {
            Console.WriteLine("PrimeServiceSlow");
        }

        public bool IsPrime(int? candidate)
        {
            if (candidate == null || candidate < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor < candidate.Value; divisor++)
            {
                if (candidate % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}