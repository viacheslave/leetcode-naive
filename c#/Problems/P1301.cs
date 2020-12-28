using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-paths-with-max-score
  ///    Submission: https://leetcode.com/submissions/detail/435597901/
  /// </summary>
  internal class P1301
  {
    public class Solution
    {
      public int[] PathsWithMaxScore(IList<string> board)
      {
        var mod = (int)1e9 + 7;
        var length = board.Count;

        var dpSum = new int[length, length];
        var dpCount = new int[length, length];

        dpCount[0, 0] = 1;

        // impossible paths
        if (board[0][0] == 'X' || board[length - 1][length - 1] == 'X')
          return new int[] { 0, 0 };

        for (var i = 1; i < 2 * length - 1; i++)
        {
          var row = i;
          var col = 0;

          if (i >= length)
          {
            row = length - 1;
            col = i - length + 1;
          }

          // go diagonal incrementally
          while (row >= 0 && col < length)
          {
            if (board[row][col] == 'X')
            {
              row--;
              col++;
              continue;
            }

            // prev cells
            var prev = new List<(int r, int c)>
            {
              (row - 1, col),
              (row - 1, col - 1),
              (row, col - 1)
            };

            var cell = board[row][col] == 'S'
              ? 0
              : int.Parse(board[row][col].ToString());

            var max = 0;

            // find max sum from prev cells + current
            foreach (var p in prev)
              if (p.r >= 0 && p.c >= 0 && p.r < length && p.c < length)
                max = Math.Max(max, dpSum[p.r, p.c] + cell);

            var count = 0;

            // find count of ways for that max sum
            foreach (var p in prev)
            {
              if (p.r >= 0 && p.c >= 0 && p.r < length && p.c < length)
              {
                if (dpSum[p.r, p.c] + cell == max)
                {
                  count += dpCount[p.r, p.c];
                  count %= mod;
                }
              }
            }

            dpSum[row, col] = max;
            dpCount[row, col] = count;

            row--;
            col++;
          }
        }

        var maxP = dpSum[length - 1, length - 1];
        var maxC = dpCount[length - 1, length - 1];

        if (maxC == 0)
          maxP = 0;

        return new int[] { maxP, maxC };
      }
    }
  }
}
