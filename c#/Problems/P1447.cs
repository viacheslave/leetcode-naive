using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/simplified-fractions/
  ///    Submission: https://leetcode.com/submissions/detail/344059427/	
  /// </summary>
  internal class P1447
  {
    public class Solution
    {
      public IList<string> SimplifiedFractions(int n)
      {
        var map = new Dictionary<int, HashSet<int>>();
        for (int i = 2; i <= n; i++)
          map[i] = GetDivisors(i).Distinct().ToHashSet();

        var ans = new List<string>();

        for (int i = 1; i < n; i++)
        {
          if (i == 1)
          {
            ans.AddRange(Enumerable.Range(2, n - 1).Select(x => $"1/{x}"));
            continue;
          }

          for (int j = i + 1; j <= n; j++)
          {
            if (map[i].Overlaps(map[j]))
              continue;

            ans.Add($"{i}/{j}");
          }
        }

        return ans;
      }

      private List<int> GetDivisors(int n)
      {
        var primes = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
        var divisors = new List<int>();

        foreach (var prime in primes)
        {
          while (n % prime == 0)
          {
            n = n / prime;
            divisors.Add(prime);
          }
        }

        return divisors;
      }
    }
  }
}
