using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/consecutive-numbers-sum/
  ///    Submission: https://leetcode.com/submissions/detail/424638530/
  /// </summary>
  internal class P0829
  {
    public class Solution
    {
      public int ConsecutiveNumbersSum(int N)
      {
        var sqrt = Math.Sqrt(N);

        var ans = 1;
        for (var i = 2; i <= sqrt; i++)
        {
          if (N % i == 0)
          {
            if (i % 2 == 1) ans++;
            if (i != (N / i) && (N / i) % 2 == 1) ans++;
          }
        }

        if (N > 1 && N % 2 == 1)
          ans++;

        return ans;
      }
    }
  }
}
