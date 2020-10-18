using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
  ///    Submission: https://leetcode.com/submissions/detail/406171988/
  /// </summary>
  internal class P1335
  {
    public class Solution
    {
      public int MinDifficulty(int[] jobDifficulty, int d)
      {
        // 6,5,4,3,2,1
        var dp = new int[jobDifficulty.Length, d];

        for (var i = 0; i < jobDifficulty.Length; ++i)
          for (var j = 0; j < d; ++j)
            dp[i, j] = int.MinValue;

        var ans = GetDP(dp, 0, d - 1, jobDifficulty);

        return ans;
      }

      private int GetDP(int[,] dp, int index, int cuts, int[] jobs)
      {
        if (dp[index, cuts] != int.MinValue)
          return dp[index, cuts];

        if (cuts == 0)
          return GetMax(jobs, index, jobs.Length - index);

        if (cuts + 1 > jobs.Length - index)
          return -1;

        var difficulty = int.MaxValue;

        for (var i = index + 1; i < jobs.Length; ++i)
        {
          var diff = GetMax(jobs, index, i - index);
          var cut = GetDP(dp, i, cuts - 1, jobs);

          if (cut != -1)
            difficulty = Math.Min(difficulty, diff + cut);
        }

        dp[index, cuts] = difficulty == int.MaxValue ? -1 : difficulty;
        return difficulty;
      }

      private int GetMax(int[] arr, int start, int count)
      {
        var max = int.MinValue;
        for (var index = 0; index < count; ++index)
          max = Math.Max(max, arr[start + index]);

        return max;
      }
    }
  }
}
