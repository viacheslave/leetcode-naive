using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/arithmetic-subarrays/
  ///    Submission: https://leetcode.com/submissions/detail/412910590/
  /// </summary>
  internal class P1630
  {
    public class Solution
    {
      public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
      {
        var ans = new List<bool>();

        for (var i = 0; i < l.Length; i++)
          ans.Add(IsArith(nums, l[i], r[i]));

        return ans;
      }

      private bool IsArith(int[] nums, int l, int r)
      {
        var arr = new int[r - l + 1];
        Array.Copy(nums, l, arr, 0, r - l + 1);
        Array.Sort(arr);

        var diffs = new List<int>();

        for (var i = 0; i < arr.Length - 1; i++)
          diffs.Add(arr[i + 1] - arr[i]);

        return diffs.Distinct().Count() == 1;
      }
    }
  }
}
