using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/max-increase-to-keep-city-skyline/
  ///    Submission: https://leetcode.com/submissions/detail/240537089/
  /// </summary>
  internal class P0807
  {
    public class Solution
    {
      public int MaxIncreaseKeepingSkyline(int[][] grid)
      {
        var mrow = new int[grid.Length];
        var mcol = new int[grid[0].Length];

        for (int i = 0; i < grid.Length; i++)
          mrow[i] = grid[i].Max();

        for (int j = 0; j < grid[0].Length; j++)
        {
          mcol[j] = int.MinValue;
          for (int i = 0; i < grid.Length; i++)
            mcol[j] = Math.Max(mcol[j], grid[i][j]);
        }

        var amount = 0;
        for (int i = 0; i < grid.Length; i++)
          for (int j = 0; j < grid[0].Length; j++)
            amount += Math.Min(mrow[i], mcol[j]) - grid[i][j];

        return amount;
      }
    }
  }
}
