using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-cost-to-cut-a-stick/
  ///    Submission: https://leetcode.com/submissions/detail/414621111/
  /// </summary>
  internal class P1547
  {
    public class Solution
    {
      public int MinCost(int n, int[] cuts)
      {
        var ct = new SortedSet<int>(cuts);
        ct.Add(0);
        ct.Add(n);

        var dp = new Dictionary<(int, int), int>();
        DP(ct, 0, n, dp);

        return dp[(0, n)];
      }

      private int DP(SortedSet<int> ct, int from, int to, Dictionary<(int, int), int> dp)
      {
        if (dp.ContainsKey((from, to)))
          return dp[(from, to)];

        int ans = int.MaxValue;

        var view = ct.GetViewBetween(from, to);

        if (view.Count == 3)
        {
          ans = to - from;
        }
        else if (view.Count == 2)
        {
          ans = 0;
        }
        else
        {
          var arr = view.ToArray();

          for (var k = 1; k < arr.Length - 1; k++)
          {
            var current =
              DP(ct, arr[0], arr[k], dp) +
              DP(ct, arr[k], arr[^1], dp) +
              (to - from);

            ans = Math.Min(ans, current);
          }
        }

        dp[(from, to)] = ans;
        return ans;
      }
    }
  }
}
