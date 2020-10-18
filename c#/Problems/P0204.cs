using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-primes/
  ///    Submission: https://leetcode.com/submissions/detail/227366292/
  /// </summary>
  internal class P0204
  {
    public class Solution
    {
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
    }
  }
}
