using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/merge-sorted-array/
  ///    Submission: https://leetcode.com/submissions/detail/227844212/
  /// </summary>
  internal class P0088
  {
    public class Solution
    {
      public void Merge(int[] nums1, int m, int[] nums2, int n)
      {


        var topLength = m;
        var topCurrent = 0;

        for (var i = 0; i < n; i++)
        {
          if (topCurrent == topLength)
          {
            nums1[topCurrent] = nums2[i];

            topCurrent++;
            topLength++;
            continue;
          }

          topCurrent = FindIndex(nums2[i], topCurrent, nums1, topLength);

          Insert(nums1, topCurrent, topLength, nums2[i]);

          topCurrent++;
          topLength++;
        }
      }



      private int FindIndex(int value, int currentIndex, int[] nums, int length)
      {
        if (value < nums[currentIndex])
          return currentIndex;

        while (currentIndex < length)
        {
          if (nums[currentIndex] == value) return currentIndex;

          if (nums[currentIndex] < value && value <= nums[currentIndex + 1])
            return currentIndex + 1;

          currentIndex++;
        }

        return currentIndex;
      }

      private void Insert(int[] nums, int index, int length, int value)
      {
        for (var i = length - 1; i >= index; i--)
        {
          nums[i + 1] = nums[i];
        }

        nums[index] = value;
      }
    }
  }
}
