using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-absolute-sum-difference/
  ///    Submission: https://leetcode.com/submissions/detail/476355103/
  /// </summary>
  internal class P1818
  {
    public class Solution
    {
      public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
      {
        var sum = Enumerable.Range(0, nums1.Length).Select(x => (long)Math.Abs(nums1[x] - nums2[x])).Sum();
        var ans = sum;
        var arr = nums1.OrderBy(x => x).ToArray();

        for (var i = 0; i < nums1.Length; ++i)
        {
          var diff = (long)Math.Abs(nums1[i] - nums2[i]);

          var n1 = BinarySearch(arr, nums2[i]);
          var d1 = (long)Math.Abs(n1 - nums2[i]);

          ans = Math.Min(ans, sum - diff + d1);
        }

        return (int)(ans % 1_000_000_007);
      }

      private int BinarySearch(int[] arr, int n2)
      {
        var left = 0;
        var right = arr.Length - 1;

        while (true)
        {
          if (right - left <= 1)
          {
            var r = arr[right] - n2;
            var l = arr[left] - n2;

            if (Math.Abs(l) < Math.Abs(r))
              return arr[left];
            else
              return arr[right];
          }

          var mid = (right + left) / 2;
          var d = arr[mid] - n2;

          if (d > 0)
            right = mid;
          else
            left = mid;
        }
      }
    }
  }
}
