using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///   Problem: https://leetcode.com/problems/best-team-with-no-conflicts/
  ///   Submission: https://leetcode.com/submissions/detail/410325246/
  /// </summary>
  internal class P1626
  {
    public int BestTeamScore(int[] scores, int[] ages)
    {
      var dp = new int[scores.Length];

      scores = Enumerable.Range(0, scores.Length)
        .Select(i => (i, score: scores[i], age: ages[i]))
        .OrderByDescending(a => a.age)
        .ThenByDescending(a => a.score)
        .Select(c => c.score)
        .ToArray();

      for (var i = 0; i < scores.Length; i++)
      {
        var value = scores[i];

        for (var j = i - 1; j >= 0; j--)
          if (scores[j] >= scores[i])
            value = Math.Max(value, dp[j] + scores[i]);

        dp[i] = value;
      }

      return dp.Max();
    }
  }
}
