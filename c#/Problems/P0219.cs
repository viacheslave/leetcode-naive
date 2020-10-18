using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/contains-duplicate-ii/
  ///    Submission: https://leetcode.com/submissions/detail/228688596/
  /// </summary>
  internal class P0219
  {
    public class Solution
    {
      public bool ContainsNearbyDuplicate(int[] nums, int k)
      {
        var map = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
          if (map.ContainsKey(nums[i]))
          {
            if (i - map[nums[i]] <= k)
              return true;
            else
              map[nums[i]] = i;
          }
          else
          {
            map[nums[i]] = i;
          }
        }

        return false;
      }
    }
  }
}
