using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-subarray-sum-with-one-deletion/
  ///    Submission: https://leetcode.com/submissions/detail/418919284/
  /// </summary>
  internal class P1186
  {
    public class Solution
    {
      public int MaximumSum(int[] arr)
      {
        var pref = new int[arr.Length];
        var suff = new int[arr.Length];

        pref[0] = arr[0];
        for (var i = 1; i < arr.Length; i++)
          pref[i] = Math.Max(pref[i - 1] + arr[i], arr[i]);

        suff[arr.Length - 1] = arr[^1];
        for (var i = arr.Length - 2; i >= 0; i--)
          suff[i] = Math.Max(suff[i + 1] + arr[i], arr[i]);

        var ans = pref[arr.Length - 1];

        if (arr.Length == 1)
          return ans;

        for (var i = 0; i < arr.Length; i++)
        {
          if (i == 0)
          {
            ans = Math.Max(ans, suff[1]);
          }
          else if (i == arr.Length - 1)
          {
            ans = Math.Max(ans, pref[arr.Length - 1 - 1]);
          }
          else
          {
            ans = Math.Max(ans, pref[i - 1] + suff[i + 1]);
            ans = Math.Max(ans, pref[i - 1]);
            ans = Math.Max(ans, suff[i + 1]);
          }
        }

        return ans;
      }
    }
  }
}
