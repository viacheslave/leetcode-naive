using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/as-far-from-land-as-possible/
	///		Submission: https://leetcode.com/submissions/detail/289827748/
	/// </summary>
	internal class P1162
	{
    public int MaxDistance(int[][] grid)
    {
      var map = new Dictionary<(int, int), int>();
      var q = new Queue<(int, int, int)>();

      var land = new List<(int, int)>();
      for (int i = 0; i < grid.Length; i++)
        for (int j = 0; j < grid[i].Length; j++)
          if (grid[i][j] == 1)
            land.Add((i, j));

      if (land.Count == 0 || land.Count == grid.Length * grid[0].Length)
        return -1;

      foreach (var item in land)
        q.Enqueue((item.Item1, item.Item2, 0));

      while (q.Count > 0)
      {
        var item = q.Dequeue();
        if (map.ContainsKey((item.Item1, item.Item2)))
          continue;

        map[(item.Item1, item.Item2)] = item.Item3;

        var ways = GetWays(grid, item);
        foreach (var way in ways)
          q.Enqueue((way.Item1, way.Item2, item.Item3 + 1));
      }

      return map.Max(s => s.Value);
    }

    private List<(int, int)> GetWays(int[][] grid, (int x, int y, int dist) item)
    {
      var ans = new List<(int, int)>();

      if (item.y - 1 >= 0 && grid[item.x][item.y - 1] == 0)
        ans.Add((item.x, item.y - 1));

      if (item.y + 1 < grid.Length && grid[item.x][item.y + 1] == 0)
        ans.Add((item.x, item.y + 1));

      if (item.x - 1 >= 0 && grid[item.x - 1][item.y] == 0)
        ans.Add((item.x - 1, item.y));

      if (item.x + 1 < grid[0].Length && grid[item.x + 1][item.y] == 0)
        ans.Add((item.x + 1, item.y));

      return ans;
    }
  }
}
