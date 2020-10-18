using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/majority-element-ii/
  ///    Submission: https://leetcode.com/submissions/detail/235229321/
  /// </summary>
  internal class P0229
  {
    public class Solution
    {
      public IList<int> MajorityElement(int[] nums)
      {
        var map = new Dictionary<int, int>();
        foreach (var n in nums)
        {
          if (!map.ContainsKey(n)) map[n] = 0;
          map[n]++;
        }

        return map
            .Where(_ => _.Value > nums.Length / 3)
            .Select(_ => _.Key)
            .ToList();
      }
    }
  }
}
