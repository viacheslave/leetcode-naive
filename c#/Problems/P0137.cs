using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/single-number-ii/
  ///    Submission: https://leetcode.com/submissions/detail/235008648/
  /// </summary>
  internal class P0137
  {
    public class Solution
    {
      public int SingleNumber(int[] nums)
      {
        var map = new Dictionary<int, int>();

        foreach (var n in nums)
        {
          if (!map.ContainsKey(n))
            map[n] = 0;

          map[n]++;
        }

        return map.First(_ => _.Value == 1).Key;
      }
    }
  }
}
