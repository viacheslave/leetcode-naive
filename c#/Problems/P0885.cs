using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/spiral-matrix-iii/
  ///    Submission: https://leetcode.com/submissions/detail/239795933/
  /// </summary>
  internal class P0885
  {
    public class Solution
    {
      public int[][] SpiralMatrixIII(int R, int C, int r0, int c0)
      {
        var visited = new HashSet<(int, int)>();
        var inbound = new List<(int, int)>();

        var dir = Dir.Top;
        var current = (r0, c0);

        visited.Add(current);
        inbound.Add(current);

        while (inbound.Count < R * C)
        {
          var next = GetNext(current, dir);

          if (visited.Contains(next))
          {
            var forward = GetForward(current, dir);

            visited.Add(forward);
            if (forward.Item1 >= 0 && forward.Item2 >= 0 && forward.Item1 < R && forward.Item2 < C)
              inbound.Add(forward);

            current = forward;
          }
          else
          {
            visited.Add(next);
            if (next.Item1 >= 0 && next.Item2 >= 0 && next.Item1 < R && next.Item2 < C)
              inbound.Add(next);

            current = next;

            dir = (Dir)((int)(dir + 1) % 4);
          }
        }

        return inbound
            .Select(_ => new int[] { _.Item1, _.Item2 })
            .ToArray();
      }

      private (int, int) GetNext((int, int) current, Dir dir)
      {
        switch (dir)
        {
          case Dir.Top:
            return (current.Item1, current.Item2 + 1);
          case Dir.Bottom:
            return (current.Item1, current.Item2 - 1);
          case Dir.Right:
            return (current.Item1 - 1, current.Item2);
          case Dir.Left:
            return (current.Item1 + 1, current.Item2);
        }
        throw new ArgumentException();
      }

      private (int, int) GetForward((int, int) current, Dir dir)
      {
        switch (dir)
        {
          case Dir.Top:
            return (current.Item1 - 1, current.Item2);
          case Dir.Bottom:
            return (current.Item1 + 1, current.Item2);
          case Dir.Right:
            return (current.Item1, current.Item2 - 1);
          case Dir.Left:
            return (current.Item1, current.Item2 + 1);
        }
        throw new ArgumentException();
      }

      public enum Dir
      {
        Top,
        Left,
        Bottom,
        Right
      }
    }
  }
}
