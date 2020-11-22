using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-flips-to-convert-binary-matrix-to-zero-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/422915328/
  /// </summary>
  internal class P1284
  {
    public class Solution
    {
      public int MinFlips(int[][] mat)
      {
        var rows = mat.Length;
        var cols = mat[0].Length;

        var mat2 = new int[rows, cols];
        for (var i = 0; i < rows; i++)
          for (var j = 0; j < cols; j++)
            mat2[i, j] = mat[i][j];

        var target = GetInt(mat2, rows, cols);

        var count = (int)Math.Pow(2, rows * cols);

        var dp = new int[count];
        for (var i = 0; i < count; i++)
          dp[i] = int.MaxValue;

        var queue = new Queue<(int[,] mat, HashSet<(int i, int j)> visited, int steps)>();
        queue.Enqueue((new int[rows, cols], new HashSet<(int, int)>(), 0));

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();
          var irep = GetInt(item.mat, rows, cols);

          // min
          if (dp[irep] == int.MaxValue || dp[irep] > item.steps)
            dp[irep] = item.steps;
          else
            continue;

          // target found
          if (irep == target)
            continue;

          var paths = GetPaths(item.mat, item.visited, rows, cols);

          foreach (var path in paths)
            queue.Enqueue((path.mat, path.visited, item.steps + 1));
        }

        return dp[target] == int.MaxValue ? -1 : dp[target];
      }

      private List<(int[,] mat, HashSet<(int i, int j)> visited)> GetPaths(int[,] mat, HashSet<(int i, int j)> visited, int rows, int cols)
      {
        var ans = new List<(int[,] mat, HashSet<(int i, int j)> visited)>();

        for (var i = 0; i < rows; i++)
        {
          for (var j = 0; j < cols; j++)
          {
            if (visited.Contains((i, j)))
              continue;

            var m = Copy(mat, rows, cols);
            Flip(m, i, j, rows, cols);

            var v = visited.ToHashSet();
            v.Add((i, j));

            ans.Add((m, v));
          }
        }

        return ans;
      }

      private int GetInt(int[,] mat, int rows, int cols)
      {
        var ans = 0;

        for (var i = 0; i < rows; i++)
          for (var j = 0; j < cols; j++)
            ans += mat[i, j] == 1 ? ((int)Math.Pow(2, cols * i + j)) : 0;

        return ans;
      }

      private void Flip(int[,] copy, int i, int j, int rows, int cols)
      {
        copy[i, j] = 1 - copy[i, j];
        if (i - 1 >= 0)
          copy[i - 1, j] = 1 - copy[i - 1, j];
        if (i + 1 < rows)
          copy[i + 1, j] = 1 - copy[i + 1, j];
        if (j - 1 >= 0)
          copy[i, j - 1] = 1 - copy[i, j - 1];
        if (j + 1 < cols)
          copy[i, j + 1] = 1 - copy[i, j + 1];
      }

      private int[,] Copy(int[,] zero, int rows, int cols)
      {
        var copy = new int[rows, cols];
        for (var i = 0; i < rows; i++)
          for (var j = 0; j < cols; j++)
            copy[i, j] = zero[i, j];

        return copy;
      }
    }
  }
}
