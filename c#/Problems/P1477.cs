using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum/ 
  ///    Submission: https://leetcode.com/submissions/detail/429316567/
  /// </summary>
  internal class P1477
  {
    public class Solution
    {
      public int MinSumOfLengths(int[] arr, int target)
      {
        var prefixSum = new int[arr.Length + 1];
        for (var i = 0; i < arr.Length; i++)
          prefixSum[i + 1] = arr[i] + prefixSum[i];

        var pre = new int[arr.Length];
        var suf = new int[arr.Length];

        var left = 0;
        var right = 0;

        // two-pointer
        // fill pre[] and suf[] arrays with length of array sum eq. to target
        // that borders with left or right index
        while (left < arr.Length)
        {
          if (left > right)
            right = left;

          while (right + 1 < arr.Length && prefixSum[right + 1] - prefixSum[left] < target)
            right++;

          if (prefixSum[right + 1] - prefixSum[left] == target)
            suf[left] = pre[right] = right - left + 1;

          left++;
        }

        // transform pre[] and suf[] to rolling min arr length of sum eq. target
        for (var i = 1; i < arr.Length; i++)
        {
          pre[i] = pre[i] == 0
            ? pre[i - 1]
            : pre[i - 1] == 0 ? pre[i] : Math.Min(pre[i], pre[i - 1]);

          suf[arr.Length - i - 1] = suf[arr.Length - i - 1] == 0
            ? suf[arr.Length - i]
            : suf[arr.Length - i] == 0 ? suf[arr.Length - i - 1] : Math.Min(suf[arr.Length - i - 1], suf[arr.Length - i]);
        }

        var min = (int)1e5 + 1;

        // check min sum of both sides
        for (var i = 1; i < arr.Length; i++)
          if (pre[i - 1] != 0 && suf[i] != 0)
            min = Math.Min(min, pre[i - 1] + suf[i]);

        return min == ((int)1e5 + 1) ? -1 : min;
      }
    }
  }
}
