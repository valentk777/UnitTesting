namespace PrimeNumberCalculator.Primes
{
    public class PrimeService : IPrimeService
    {
        public bool IsPrime(int? candidate)
        {
            if (candidate == null || candidate < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(candidate.Value); divisor++)
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