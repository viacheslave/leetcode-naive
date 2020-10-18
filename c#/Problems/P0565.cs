using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/array-nesting/
  ///    Submission: https://leetcode.com/submissions/detail/248115159/
  /// </summary>
  internal class P0565
  {
    public class Solution
    {
      public int ArrayNesting(int[] nums)
      {
        var chains = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
          var set = new HashSet<int>();
          var list = new List<int>();

          int value = nums[i];
          bool inchain = false;

          while (true)
          {
            if (set.Contains(value))
              break;

            if (chains.ContainsKey(value))
            {
              inchain = true;
              break;
            }

            set.Add(value);
            list.Add(value);

            value = nums[value];
          }

          for (int j = 0; j < list.Count; j++)
          {
            chains.Add(list[j], list.Count - j + (inchain ? chains[value] : 0));
          }
        }

        return chains.Max(_ => _.Value);
      }
    }
  }
}
