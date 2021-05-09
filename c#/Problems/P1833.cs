using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-ice-cream-bars/
  ///    Submission: https://leetcode.com/submissions/detail/490784509/
  /// </summary>
  internal class P1833
  {
    public class Solution
    {
      public int MaxIceCream(int[] costs, int coins)
      {
        Array.Sort(costs);

        var ans = 0;
        var index = 0;

        while (coins > 0)
        {
          if (index == costs.Length)
            break;

          if (costs[index] <= coins)
          {
            ans++;
            coins -= costs[index];
            index++;
            continue;
          }

          break;
        }

        return ans;
      }
    }
  }
}
