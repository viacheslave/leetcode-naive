using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///		Problem: https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid/
  ///		Submission: https://leetcode.com/submissions/detail/318739504/
  /// </summary>
  internal class P1391
	{
    public bool HasValidPath(int[][] grid)
    {
      var dirs = new List<string>();

      switch (grid[0][0])
      {
        case 1:
        case 6: dirs = new List<string> { "r" }; break;
        case 2:
        case 3: dirs = new List<string> { "d" }; break;
        case 4: dirs = new List<string> { "r", "d" }; break;
      }

      if (dirs.Count == 0)
        return false;

      if (dirs.Count == 1)
        return Verify(dirs[0], grid);

      return Verify(dirs[0], grid) || Verify(dirs[1], grid);
    }

    private bool Verify(string dir, int[][] grid)
    {
      var map = new Dictionary<string, int[]>
      {
        ["r"] = new int[] { 1, 3, 5 },
        ["l"] = new int[] { 1, 4, 6 },
        ["u"] = new int[] { 2, 3, 4 },
        ["d"] = new int[] { 2, 5, 6 },
      };

      var visited = new HashSet<(int, int)>();
      var pos = (0, 0);
      var end = (grid.Length - 1, grid[0].Length - 1);

      while (true)
      {
        if (visited.Contains(pos))
          return false;

        visited.Add(pos);

        if (pos == end)
          return true;

        var next = pos;
        switch (dir)
        {
          case "r": next = (pos.Item1, pos.Item2 + 1); break;
          case "l": next = (pos.Item1, pos.Item2 - 1); break;
          case "u": next = (pos.Item1 - 1, pos.Item2); break;
          case "d": next = (pos.Item1 + 1, pos.Item2); break;
        }

        if (next.Item1 < 0 || next.Item1 > end.Item1)
          return false;
        if (next.Item2 < 0 || next.Item2 > end.Item2)
          return false;

        var nextForm = grid[next.Item1][next.Item2];
        var validForms = map[dir];

        if (!validForms.Contains(nextForm))
          return false;

        pos = next;

        switch (dir)
        {
          case "r":
            if (nextForm == 1) dir = "r";
            if (nextForm == 3) dir = "d";
            if (nextForm == 5) dir = "u";
            break;
          case "l":
            if (nextForm == 1) dir = "l";
            if (nextForm == 4) dir = "d";
            if (nextForm == 6) dir = "u";
            break;
          case "u":
            if (nextForm == 2) dir = "u";
            if (nextForm == 3) dir = "l";
            if (nextForm == 4) dir = "r";
            break;
          case "d":
            if (nextForm == 2) dir = "d";
            if (nextForm == 5) dir = "l";
            if (nextForm == 6) dir = "r";
            break;
        }
      }
    }
  }
}
