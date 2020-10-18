using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/non-overlapping-intervals/
  ///    Submission: https://leetcode.com/submissions/detail/381301033/
  /// </summary>
  internal class P0435
  {
    public class Solution
    {
      public int EraseOverlapIntervals(int[][] intervals)
      {
        if (intervals.Length <= 1)
          return 0;

        var list = intervals.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();

        int count = 0;
        int end = list[0][1];

        for (int i = 1; i < list.Count; i++)
        {
          int[] interval = list[i];
          if (interval[0] < end)
          {
            count++;
            end = Math.Min(end, interval[1]);
          }
          else
          {
            end = interval[1];
          }
        }

        return count;
      }
    }
  }
}
