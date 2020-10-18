using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-sum-of-averages/
  ///    Submission: https://leetcode.com/submissions/detail/388096105/
  /// </summary>
  internal class P0813
  {
    public class Solution
    {
      public double LargestSumOfAverages(int[] A, int K)
      {
        var dp = new Dictionary<(int, int, int), double>();
        var ans = Max(dp, A, 0, A.Length - 1, K);
        return ans;
      }

      private double Max(Dictionary<(int, int, int), double> dp, int[] a, int v1, int v2, int k)
      {
        if (k == 1)
          return a.Skip(v1).Take(v2 - v1 + 1).Average(); ;

        if (dp.ContainsKey((v1, v2, k)))
          return dp[(v1, v2, k)];

        if (v2 == v1)
        {
          dp[(v1, v2, k)] = v1;
          return a[v1];
        }

        var list = new List<double>();
        for (var i = v2 - 1; i >= v1; i--)
        {
          var left = a.Skip(v1).Take(i - v1 + 1).Average();

          if (k - 1 == 1)
          {
            left += a.Skip(i + 1).Take(v2 - i).Average();
          }
          else if (i + 1 == v2)
          {
            left += a[v2];
          }
          else
          {
            left += Max(dp, a, i + 1, v2, k - 1);
          }

          list.Add(left);
        }

        var max = list.Max();
        dp[(v1, v2, k)] = max;

        return max;
        ;
      }
    }
  }
}
