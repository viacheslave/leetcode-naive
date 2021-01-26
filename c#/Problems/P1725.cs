using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-rectangles-that-can-form-the-largest-square/
  ///    Submission: https://leetcode.com/submissions/detail/444088235/
  /// </summary>
  internal class P1725
  {
    public class Solution
    {
      public int CountGoodRectangles(int[][] rectangles)
      {
        var k = 0;

        foreach (var rect in rectangles)
          k = Math.Max(k, Math.Min(rect[0], rect[1]));

        var ans = 0;

        foreach (var rect in rectangles)
          ans += (rect[0] >= k && rect[1] >= k) ? 1 : 0;

        return ans;
      }
    }
  }
}
