using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/longest-increasing-path-in-a-matrix/
	///		Submission: https://leetcode.com/submissions/detail/404874544/
	/// </summary>
	internal class P0329
	{
    public int LongestIncreasingPath(int[][] matrix)
    {
      if (matrix.Length == 0)
        return 0;

      var map = new Dictionary<(int i, int j), int>();

      for (int i = 0; i < matrix.Length; i++)
        for (int j = 0; j < matrix[0].Length; j++)
          map[(i, j)] = matrix[i][j];

      map = map.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

      // DFS

      var queue = new Queue<(int i, int j, int value)>();
      var ans = new Dictionary<(int i, int j), int>();

      var first = map.First();
      queue.Enqueue((first.Key.i, first.Key.j, 1));

      while (queue.Count > 0)
      {
        var el = queue.Dequeue();

        map.Remove((el.i, el.j));

        if (!ans.ContainsKey((el.i, el.j)) || ans[(el.i, el.j)] < el.value)
        {
          ans[(el.i, el.j)] = el.value;

          var points = GetPoints(el, matrix);

          foreach (var (i, j) in points)
          {
            if (matrix[i][j] > matrix[el.i][el.j])
              queue.Enqueue((i, j, el.value + 1));
          }
        }

        if (queue.Count == 0 && map.Count > 0)
        {
          first = map.First();
          queue.Enqueue((first.Key.i, first.Key.j, 1));
        }
      }

      return ans.Max(x => x.Value);
    }

    private List<(int i, int j)> GetPoints((int i, int j, int value) el, int[][] matrix)
    {
      var points = new List<(int i, int j)> {
            (el.i + 1, el.j),
            (el.i - 1, el.j),
            (el.i, el.j + 1),
            (el.i, el.j - 1)
        };

      var ans = new List<(int i, int j)>();

      foreach (var point in points)
      {
        if (point.i >= 0 && point.i < matrix.Length &&
            point.j >= 0 && point.j < matrix[0].Length)
        {
          ans.Add(point);
        }
      }

      return ans;
    }
  }
}
