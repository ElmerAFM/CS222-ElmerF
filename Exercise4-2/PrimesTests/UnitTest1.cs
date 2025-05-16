using Xunit;
using PrimesLib;

namespace PrimesTests
{
    public class UnitTest1Test
    {
        [Fact]
        public void PrimeFactorsOf4()
        {
            int number = 4;
            string expected = "2 x 2";
            string actual = Primes.PrimeFactors(number);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrimeFactorsOf7()
        {
            int number = 7;
            string expected = "7";
            string actual = Primes.PrimeFactors(number);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrimeFactorsOf30()
        {
            int number = 30;
            string expected = "5 x 3 x 2";
            string actual = Primes.PrimeFactors(number);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrimeFactorsOf40()
        {
            int number = 40;
            string expected = "5 x 2 x 2 x 2";
            string actual = Primes.PrimeFactors(number);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PrimeFactorsOf50()
        {
            int number = 50;
            string expected = "5 x 5 x 2";
            string actual = Primes.PrimeFactors(number);
            Assert.Equal(expected, actual);
        }
    }
}