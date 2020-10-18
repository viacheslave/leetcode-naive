using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/prime-arrangements/
  ///    Submission: https://leetcode.com/submissions/detail/258573711/
  /// </summary>
  internal class P1175
  {
    public class Solution
    {
      public int NumPrimeArrangements(int n)
      {
        var mod = 1_000_000_007;
        var numOfPrimes = CountPrimes(n + 1);

        var factPrimes = GetFact(numOfPrimes) % mod;
        var factNonPrimes = GetFact(n - numOfPrimes) % mod;

        return (int)((new BigInteger(factPrimes) * new BigInteger(factNonPrimes)) % mod);
      }

      public int CountPrimes(int n)
      {
        if (n < 2)
          return 0;

        var primes = new List<int>();
        var skip = new HashSet<int>();

        for (var i = 2; i < n; i++)
        {
          if (skip.Contains(i))
            continue;

          var isPrime = true;

          for (var pi = 0; pi < primes.Count; pi++)
          {
            if (i % primes[pi] == 0)
            {
              isPrime = false;
              break;
            }

            if (primes[pi] * primes[pi] > i)
              break;
          }

          if (isPrime)
          {
            primes.Add(i);

            for (var j = i * 2; j < n; j += i)
            {
              skip.Add(j);
            }
          }
        }

        return primes.Count;
      }

      private int GetFact(int n)
      {
        var mod = 1_000_000_007;

        BigInteger ret = 1;
        for (int i = 1; i <= n; i++)
          ret = ((ret % mod) * (i % mod)) % mod;

        return (int)ret;
      }
    }
  }
}
