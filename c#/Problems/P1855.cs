using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-distance-between-a-pair-of-values/
  ///    Submission: https://leetcode.com/submissions/detail/490839543/
  /// </summary>
  internal class P1855
  {
    public class Solution
    {
      public int MaxDistance(int[] nums1, int[] nums2)
      {
        var ans = 0;

        for (var i = 0; i < nums1.Length; i++)
        {
          if (i >= nums2.Length)
            continue;

          if (nums1[i] > nums2[i])
            continue;

          var j = BinarySearch(nums2, nums1[i], i, nums2.Length - 1);
          ans = Math.Max(ans, j - i);
        }

        return ans;
      }

      private int BinarySearch(int[] nums2, int val, int from, int to)
      {
        while (true)
        {
          if (to - from <= 1)
            return val <= nums2[to] ? to : from;

          var mid = (from + to) / 2;
          if (val <= nums2[mid])
            from = mid;
          else
            to = mid;
        }
      }
    }
  }
}
