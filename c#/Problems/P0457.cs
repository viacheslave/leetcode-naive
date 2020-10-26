using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/circular-array-loop/
  ///    Submission: https://leetcode.com/submissions/detail/413303203/
  /// </summary>
  internal class P0457
  {
    public class Solution
    {
      public bool CircularArrayLoop(int[] nums)
      {
        var indices = Enumerable.Range(0, nums.Length).ToHashSet();

        while (indices.Count > 0)
        {
          var res = Loop(nums, indices);
          if (res)
            return true;
        }

        return false;
      }

      private bool Loop(int[] nums, HashSet<int> indices)
      {
        var visited = new Dictionary<int, (int counter, int metric)>();
        var position = indices.First();
        var counter = 0;
        var metric = 0;

        while (true)
        {
          if (visited.ContainsKey(position))
          {
            var entry = visited[position];

            var diffCounter = counter - entry.counter;
            var diffMetric = Math.Abs(metric - entry.metric);

            if (diffMetric == diffCounter && diffCounter > 1)
              return true;

            return false;
          }

          if (indices.Count == 0)
            break;

          visited.Add(position, (counter, metric));

          var el = nums[position];
          if (el > 0)
            metric++;
          else
            metric--;

          indices.Remove(position);

          position += el;
          if (el > 0)
          {
            position %= nums.Length;
          }
          else
          {
            if (position < 0)
            {
              position = nums.Length - (Math.Abs(position) % nums.Length);
            }
          }

          counter++;
        }

        return false;
      }
    }
  }
}
