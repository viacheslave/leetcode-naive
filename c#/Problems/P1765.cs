using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/map-of-highest-peak/
  ///    Submission: https://leetcode.com/submissions/detail/490968151/
  /// </summary>
  internal class P1765
  {
    public class Solution
    {
      public int[][] HighestPeak(int[][] isWater)
      {
        var rows = isWater.Length;
        var cols = isWater[0].Length;

        for (var i = 0; i < rows; i++)
          for (var j = 0; j < cols; j++)
            isWater[i][j] = isWater[i][j] == 1 ? 0 : -1;

        var land = new List<(int x, int y)>();

        for (var i = 0; i < rows; i++)
          for (var j = 0; j < cols; j++)
            if (isWater[i][j] == 0)
              land.Add((i, j));

        var currentHeight = 0;

        while (land.Count > 0)
        {
          var nextLand = new List<(int x, int y)>();

          foreach (var (x, y) in land)
          {
            var dirs = new List<(int x, int y)>
            {
              (x + 1, y),
              (x - 1, y),
              (x, y + 1),
              (x, y - 1)
            };

            foreach (var dir in dirs)
            {
              if (dir.x < 0 || dir.x >= rows || dir.y < 0 || dir.y >= cols)
                continue;

              if (isWater[dir.x][dir.y] == -1)
              {
                isWater[dir.x][dir.y] = currentHeight + 1;
                nextLand.Add(dir);
              }
            }
          }

          land = nextLand;
          currentHeight++;
        }

        return isWater;
      }
    }
  }
}
