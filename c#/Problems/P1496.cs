using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/path-crossing/
  ///    Submission: https://leetcode.com/submissions/detail/387144500/
  /// </summary>
  internal class P1496
  {
    public class Solution
    {
      public bool IsPathCrossing(string path)
      {
        var points = new HashSet<(int, int)>();

        var current = (0, 0);
        points.Add(current);

        foreach (var item in path)
        {
          if (item == 'N')
            current = (current.Item1, current.Item2 + 1);
          if (item == 'S')
            current = (current.Item1, current.Item2 - 1);
          if (item == 'E')
            current = (current.Item1 + 1, current.Item2);
          if (item == 'W')
            current = (current.Item1 - 1, current.Item2);

          if (points.Contains(current))
            return true;

          points.Add(current);
        }

        return false;
      }
    }
  }
}
