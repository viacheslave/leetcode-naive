using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-equivalent-domino-pairs/
  ///    Submission: https://leetcode.com/submissions/detail/245739128/
  /// </summary>
  internal class P1128
  {
    public class Solution
    {
      public int NumEquivDominoPairs(int[][] dominoes)
      {
        var count = 0;

        for (int i = 0; i < dominoes.Length; i++)
        {
          if (dominoes[i][0] > dominoes[i][1])
            dominoes[i] = new int[] { dominoes[i][1], dominoes[i][0] };
        }

        return dominoes
            .GroupBy(_ => (_[0], _[1]))
            .ToDictionary(_ => _.Key, _ => _.Count())
            .Sum(_ => (_.Value - 1) * _.Value / 2);
      }
    }
  }
}
