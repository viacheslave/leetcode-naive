using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minesweeper/
  ///    Submission: https://leetcode.com/submissions/detail/400652287/
  /// </summary>
  internal class P0529
  {
    public class Solution
    {
      public char[][] UpdateBoard(char[][] board, int[] click)
      {
        var cl = (row: click[0], col: click[1]);

        if (board[cl.row][cl.col] == 'M')
        {
          board[cl.row][cl.col] = 'X';
          return board;
        }

        var q = new Queue<(int row, int col)>();
        var visited = new HashSet<(int row, int col)>();

        q.Enqueue(cl);

        while (q.Count > 0)
        {
          var point = q.Dequeue();
          if (visited.Contains(point))
            continue;

          visited.Add(point);

          var dirs = new List<(int row, int col)>
        {
            (point.row - 1, point.col - 1),
            (point.row - 1, point.col),
            (point.row - 1, point.col + 1),
            (point.row, point.col + 1),
            (point.row + 1, point.col + 1),
            (point.row + 1, point.col),
            (point.row + 1, point.col - 1),
            (point.row, point.col - 1)
        };

          var mines = 0;

          foreach (var dir in dirs)
          {
            if (dir.row >= 0 && dir.row < board.Length
                && dir.col >= 0 && dir.col < board[0].Length)
            {
              if (board[dir.row][dir.col] == 'M')
                mines++;
            }
          }

          if (mines == 0)
          {
            board[point.row][point.col] = 'B';

            foreach (var dir in dirs)
            {
              if (dir.row >= 0 && dir.row < board.Length
                  && dir.col >= 0 && dir.col < board[0].Length)
              {
                if (board[dir.row][dir.col] == 'E')
                  q.Enqueue(dir);
              }
            }
          }
          else
          {
            board[point.row][point.col] = char.Parse(mines.ToString());
          }
        }

        return board;
      }
    }
  }
}
