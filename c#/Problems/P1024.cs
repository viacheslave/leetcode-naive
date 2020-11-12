using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/video-stitching/
  ///    Submission: https://leetcode.com/submissions/detail/419556273/
  /// </summary>
  internal class P1024
  {
    public class Solution
    {
      public int VideoStitching(int[][] clips, int T)
      {
        var intervals = clips
          .Select(x => (start: x[0], end: x[1]))
          .OrderBy(x => x.start)
          .ToList();

        if (intervals[0].start > 0)
          return -1;

        var dp = new Dictionary<int, int>
        {
          [intervals[0].end] = 1
        };

        for (var i = 1; i < intervals.Count; i++)
        {
          var interval = intervals[i];
          var keys = dp.Keys.ToArray();

          foreach (var end in keys)
          {
            if (interval.start == 0)
              dp[interval.end] = 1;

            if (interval.start <= end && end <= interval.end)
            {
              if (dp.ContainsKey(interval.end))
                dp[interval.end] = Math.Min(dp[interval.end], dp[end] + 1);
              else
                dp[interval.end] = dp[end] + 1;
            }
          }
        }

        var eligible = dp.Where(x => x.Key >= T).ToList();
        if (eligible.Count == 0)
          return -1;

        return eligible.Min(x => x.Value);
      }
    }
  }
}
