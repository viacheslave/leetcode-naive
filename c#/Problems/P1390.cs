using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/four-divisors/
  ///    Submission: https://leetcode.com/submissions/detail/318723888/
  /// </summary>
  internal class P1390
  {
    public class Solution
    {
      public int SumFourDivisors(int[] nums)
      {
        var ans = 0;
        foreach (var num in nums)
          if (Fits(num, out int div))
            ans += 1 + num + div + num / div;

        return ans;
      }

      private bool Fits(int num, out int div)
      {
        div = 0;
        for (var d = 2; d <= Math.Sqrt(num); d++)
          if (num % d == 0)
            if (div == 0)
              div = d;
            else return false;

        return div != 0 && num / div != div;
      }
    }
  }
}
