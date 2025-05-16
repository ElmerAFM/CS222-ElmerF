namespace PrimesLib
{
    public class Primes
    {
        public static string PrimeFactors(int number)
        {
            List<int> factors = [];
            int n = number;
            for (int i = 2; i <= n / i; i++)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }
            if (n > 1)
                factors.Add(n);

            factors.Reverse();

            return string.Join(" x ", factors);
        }
    }
}
