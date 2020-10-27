using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-consecutive-sequence/
  ///    Submission: https://leetcode.com/submissions/detail/413769682/
  /// </summary>
  internal class P0128
  {
    public class Solution
    {
      public int LongestConsecutive(int[] nums)
      {
        if (nums.Length == 0)
          return 0;

        var dict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
          if (dict.ContainsKey(num))
            continue;

          dict[num] = num;

          if (num == int.MinValue)
          {
            if (dict.ContainsKey(num + 1))
              Union(dict, num, num + 1);

            continue;
          }

          if (num == int.MaxValue)
          {
            if (dict.ContainsKey(num - 1))
              Union(dict, num, num - 1);

            continue;
          }

          if (dict.ContainsKey(num - 1))
            Union(dict, num, num - 1);

          if (dict.ContainsKey(num + 1))
            Union(dict, num, num + 1);
        }


        var roots = new Dictionary<int, int>();

        foreach (var num in dict.Keys)
        {
          var r = GetRoot(dict, num);

          if (!roots.ContainsKey(r))
            roots[r] = 0;

          roots[r]++;
        }

        return roots.Max(x => x.Value);
      }

      private void Union(Dictionary<int, int> dict, int a, int b)
      {
        var root_a = GetRoot(dict, a);
        var root_b = GetRoot(dict, b);

        dict[root_a] = root_b;
      }

      private int GetRoot(Dictionary<int, int> dict, int a)
      {
        while (a != dict[a])
          a = dict[a];

        return a;
      }
    }
  }
}
