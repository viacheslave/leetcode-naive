using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/cyclically-rotating-a-grid/
  ///    Submission: https://leetcode.com/submissions/detail/519177753/
  /// </summary>
  internal class P1914
  {
    public class Solution
    {
      public enum Direction
      {
        Down,
        Right,
        Top,
        Left
      }

      public int[][] RotateGrid(int[][] grid, int k)
      {
        var dirs = new Dictionary<Direction, Direction>
        {
          [Direction.Down] = Direction.Right,
          [Direction.Right] = Direction.Top,
          [Direction.Top] = Direction.Left,
          [Direction.Left] = Direction.Down,
        };

        var rows = grid.Length;
        var cols = grid[0].Length;

        var ans = new int[rows][];
        for (var r = 0; r < rows; r++)
          ans[r] = new int[cols];

        for (var d = 0; d < Math.Min(rows, cols) / 2; d++)
        {
          var point = (row: d, col: d);
          var dir = Direction.Down;
          var range = (row: (from: d, to: rows - 1 - d), col: (from: d, to: cols - 1 - d));

          // get layer
          var items = new List<(int row, int col)>();

          do
          {
            var next = GetNext(point, dir);
            if (next.row < range.row.from || next.row > range.row.to ||
                next.col < range.col.from || next.col > range.col.to)
            {
              next = GetNext(point, dirs[dir]);
              dir = dirs[dir];
            }

            items.Add(next);
            point = next;
          }
          while (point != (row: d, col: d));

          // rotate layer
          var pivot = k % items.Count;
          var rotated = items.Skip(pivot).Concat(items.Take(pivot)).ToList();

          for (var i = 0; i < items.Count; i++)
            ans[rotated[i].row][rotated[i].col] = grid[items[i].row][items[i].col];
        }

        return ans;
      }

      private (int row, int col) GetNext((int row, int col) point, Direction dir)
      {
        switch (dir)
        {
          case Direction.Down:
            return (point.row + 1, point.col);
          case Direction.Right:
            return (point.row, point.col + 1);
          case Direction.Top:
            return (point.row - 1, point.col);
          default:
            return (point.row, point.col - 1);
        }
      }
    }
  }
}
