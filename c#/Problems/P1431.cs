using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
  ///    Submission: https://leetcode.com/submissions/detail/387711206/
  /// </summary>
  internal class P1431
  {
    public class Solution
    {
      public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
      {
        var ans = new List<bool>();
        var max = candies.Max();

        for (var i = 0; i < candies.Length; i++)
        {
          if (candies[i] + extraCandies >= max)
            ans.Add(true);
          else
            ans.Add(false);
        }

        return ans;
      }
    }
  }
}
