using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-initial-energy-to-finish-tasks/
  ///    Submission: https://leetcode.com/submissions/detail/422943075/
  /// </summary>
  internal class P1665
  {
    public class Solution
    {
      public int MinimumEffort(int[][] tasks)
      {
        var o = tasks
          .OrderByDescending(t => t[1] - t[0])
          .ThenByDescending(t => t[1])
          .Select(t => (actial: t[0], minimum: t[1]))
          .ToList();

        var min = Math.Min(tasks.Sum(t => t[0]), tasks.Max(t => t[1]));

        var max = min;
        while (!CanDo(o, max))
          max *= 2;

        if (min == max)
          return min;

        while (true)
        {
          if (max - min == 1)
          {
            if (CanDo(o, min))
              return min;
            return max;
          }

          var mid = (min + max) / 2;
          if (CanDo(o, mid))
            max = mid;
          else
            min = mid;
        }
      }

      private bool CanDo(List<(int actial, int minimum)> o, int value)
      {
        foreach (var task in o)
        {
          if (value >= task.minimum)
            value -= task.actial;
          else return false;
        }

        return true;
      }
    }

  }
}
