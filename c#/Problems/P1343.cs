using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-sub-arrays-of-size-k-and-average-greater-than-or-equal-to-threshold/
  ///    Submission: https://leetcode.com/submissions/detail/301693469/
  /// </summary>
  internal class P1343
  {
    public class Solution
    {
      public int NumOfSubarrays(int[] arr, int k, int threshold)
      {
        var start = 0;
        var end = start + k - 1;

        var sum = 0;
        var ans = 0;

        while (end < arr.Length)
        {
          if (start == 0)
          {
            sum = arr.Take(k).Sum();
          }
          else
          {
            sum += arr[end];
            sum -= arr[start - 1];
          }

          if (1.0 * sum / k >= threshold)
            ans++;

          start++;
          end++;
        }

        return ans;
      }
    }
  }
}
