using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/pacific-atlantic-water-flow/
  ///    Submission: https://leetcode.com/submissions/detail/248874221/
  /// </summary>
  internal class P0417
  {
    public class Solution
    {
      public IList<IList<int>> PacificAtlantic(int[][] matrix)
      {
        if (matrix.Length == 0)
          return new List<IList<int>>();

        var atlanticBorder = new HashSet<(int, int)>();

        for (int i = 0; i < matrix.Length; i++)
          atlanticBorder.Add((i, 0));

        for (int i = 0; i < matrix[0].Length; i++)
          atlanticBorder.Add((0, i));

        var bfsAtlantic = BFS(matrix, atlanticBorder);

        var pacificBorder = new HashSet<(int, int)>();

        for (int i = 0; i < matrix.Length; i++)
          pacificBorder.Add((i, matrix[0].Length - 1));

        for (int i = 0; i < matrix[0].Length; i++)
          pacificBorder.Add((matrix.Length - 1, i));

        var bfsPacific = BFS(matrix, pacificBorder);

        bfsAtlantic.IntersectWith(bfsPacific);

        return bfsAtlantic.Select(_ => (IList<int>)(new List<int> { _.Item1, _.Item2 })).ToList();
      }

      private HashSet<(int, int)> BFS(int[][] matrix, HashSet<(int, int)> start)
      {
        var pool = new HashSet<(int, int)>();

        foreach (var item in start)
        {
          var queue = new Queue<(int, int)>();
          queue.Enqueue(item);

          while (queue.Count > 0)
          {
            var el = queue.Dequeue();
            if (pool.Contains(el))
              continue;

            pool.Add(el);

            var left = (el.Item1, el.Item2 - 1);
            var right = (el.Item1, el.Item2 + 1);
            var top = (el.Item1 - 1, el.Item2);
            var bottom = (el.Item1 + 1, el.Item2);

            if (Valid(matrix, left, el)) queue.Enqueue(left);
            if (Valid(matrix, right, el)) queue.Enqueue(right);
            if (Valid(matrix, top, el)) queue.Enqueue(top);
            if (Valid(matrix, bottom, el)) queue.Enqueue(bottom);
          }
        }

        return pool;
      }

      private bool Valid(int[][] matrix, (int, int) next, (int, int) el)
      {
        return
            next.Item1 >= 0 &&
            next.Item2 >= 0 &&
            next.Item1 < matrix.Length &&
            next.Item2 < matrix[0].Length &&
            matrix[el.Item1][el.Item2] <= matrix[next.Item1][next.Item2];
      }
    }
  }
}
