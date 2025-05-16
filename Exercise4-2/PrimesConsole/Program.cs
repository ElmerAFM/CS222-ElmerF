using System;
using PrimesLib;

class Program
{
  static void Main(string[] args)
  {
    Console.Write("Enter a number to factor: ");
    if (int.TryParse(Console.ReadLine(), out int number))
    {
      string factors = Primes.PrimeFactors(number);
      Console.WriteLine("Prime factors:");
      Console.WriteLine(factors);
    }
    else
    {
      Console.WriteLine("Invalid input.");
    }
  }
}
