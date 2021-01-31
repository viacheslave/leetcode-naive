using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-highest-altitude/
  ///    Submission: https://leetcode.com/submissions/detail/450192242/
  /// </summary>
  internal class P1732
  {
    public class Solution
    {
      public int LargestAltitude(int[] gain)
      {
        var ans = 0;

        var height = 0;
        for (var i = 0; i < gain.Length; i++)
        {
          height += gain[i];
          ans = Math.Max(ans, height);
        }

        return ans;
      }
    }
  }
}
