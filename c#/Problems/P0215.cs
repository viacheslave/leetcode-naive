using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/kth-largest-element-in-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/229967283/
  /// </summary>
  internal class P0215
  {
    public class Solution
    {
      public int FindKthLargest(int[] nums, int k)
      {
        if (nums.Length == 0)
          return 0;

        if (nums.Length == 1)
          return nums[0];

        var maxArray = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
          maxArray.Add(nums[i]);

          Shift(maxArray);
        }

        return GetKthMax(maxArray, k);
      }

      private void Shift(List<int> arr)
      {
        if (arr.Count == 1)
          return;

        int index = arr.Count - 1;
        while (index > 0)
        {
          if (arr[index] > arr[index - 1])
          {
            var tmp = arr[index];
            arr[index] = arr[index - 1];
            arr[index - 1] = tmp;

            index--;
            continue;
          }
          break;
        }
      }

      private int GetKthMax(List<int> arr, int k)
      {
        return arr[k - 1];
      }
    }
  }
}
