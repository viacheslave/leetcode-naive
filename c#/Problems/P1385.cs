using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-distance-value-between-two-arrays/
  ///    Submission: https://leetcode.com/submissions/detail/314843242/
  /// </summary>
  internal class P1385
  {
    public class Solution
    {
      public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
      {
        Array.Sort(arr2);

        var ans = 0;
        for (int i = 0; i < arr1.Length; i++)
          ans += Try(arr1[i], arr2, d);

        return ans;
      }

      private int Try(int el, int[] arr, int d)
      {
        var start = 0;
        var end = arr.Length - 1;

        if (arr[start] - el > d || el - arr[end] > d)
          return 1;

        while (true)
        {
          if (start == end || end - start == 1)
          {
            var abs1 = Math.Abs(arr[start] - el);
            var abs2 = Math.Abs(arr[end] - el);

            if (abs1 > d && abs2 > d)
              return 1;
            return 0;
          }

          var mid = (start + end) / 2;
          if (el > arr[mid])
            start = mid;
          else
            end = mid;
        }
      }
    }
  }
}
