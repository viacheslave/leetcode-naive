using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/third-maximum-number/
  ///    Submission: https://leetcode.com/submissions/detail/229966588/
  /// </summary>
  internal class P0414
  {
    public class Solution
    {
      public int ThirdMax(int[] nums)
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

        return GetThirdMax(maxArray);
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

      private int GetThirdMax(List<int> arr)
      {
        int ticks = 1;
        int max = arr[0];

        foreach (var a in arr)
        {
          if (a == max)
            continue;

          if (a < max)
          {
            max = a;
            ticks++;

            if (ticks == 3)
              return max;
          }
        }

        return arr[0];
      }
    }
  }
}
