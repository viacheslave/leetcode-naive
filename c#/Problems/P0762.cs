using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/
  ///    Submission: https://leetcode.com/submissions/detail/232267975/
  /// </summary>
  internal class P0762
  {
    public class Solution
    {
      HashSet<int> p = new HashSet<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

      public int CountPrimeSetBits(int L, int R)
      {
        var count = 0;

        for (var i = L; i <= R; i++)
        {
          var pri = IsPrime(i);
          if (pri)
            count++;

        }

        return count;
      }

      private bool IsPrime(int n)
      {
        var count = 0;
        var i = 0;

        while (i < 31)
        {
          if (n % 2 == 1)
            count++;

          n = n >> 1;
          i++;
        }

        return p.Contains(count);
      }
    }
  }
}
