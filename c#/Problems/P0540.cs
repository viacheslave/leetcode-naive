using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/single-element-in-a-sorted-array/
  ///    Submission: https://leetcode.com/submissions/detail/239469295/
  /// </summary>
  internal class P0540
  {
    public class Solution
    {
      public int SingleNonDuplicate(int[] nums)
      {
        if (nums.Length == 1)
          return nums[0];

        //1,1,2,3,3,4,4,8,8
        var queue = new Queue<(int, int)>();

        queue.Enqueue((0, nums.Length - 1));

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();

          var mid = (item.Item1 + item.Item2) / 2;

          //3,4,4,5
          if (nums[mid] == nums[mid + 1])
          {
            queue.Enqueue((item.Item1, mid));
            queue.Enqueue((mid + 1, item.Item2));
            continue;
          }

          //3,3,4,4
          if (mid - 1 < 0 || nums[mid - 1] != nums[mid])
            return nums[mid];

          if (mid + 2 >= nums.Length || nums[mid + 1] != nums[mid + 2])
            return nums[mid + 1];

          queue.Enqueue((item.Item1, mid));
          queue.Enqueue((mid + 1, item.Item2));
        }

        return -1;
      }
    }
  }
}
