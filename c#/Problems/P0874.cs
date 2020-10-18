using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/walking-robot-simulation/
  ///    Submission: https://leetcode.com/submissions/detail/241990134/
  /// </summary>
  internal class P0874
  {
    public class Solution
    {
      public int RobotSim(int[] commands, int[][] obstacles)
      {
        var current = (x: 0, y: 0);
        var dir = Dir.North;
        var obs = new HashSet<(int x, int y)>(obstacles.Select(_ => (_[0], _[1])));
        var max = 0;

        foreach (var command in commands)
        {
          if (command == -1)
          {
            dir = (Dir)(((int)dir + 4 + 1) % 4);
            continue;
          }

          if (command == -2)
          {
            dir = (Dir)(((int)dir + 4 - 1) % 4);
            continue;
          }

          var next = GetNext(command, obs, current, dir);
          if (next.x != current.x || next.y != current.y)
          {
            current = next;
            max = Math.Max(max, (current.x * current.x + current.y * current.y));
          }
        }

        return max;
      }

      private (int x, int y) GetNext(int steps, HashSet<(int x, int y)> obs, (int x, int y) start, Dir dir)
      {
        var current = start;
        for (int i = 0; i < steps; i++)
        {
          var next = GetNext(current, dir);
          if (obs.Contains(next))
            return current;

          current = next;
        }

        return current;
      }

      private (int x, int y) GetNext((int x, int y) current, Dir dir)
      {
        switch (dir)
        {
          case Dir.East:
            return (current.x + 1, current.y);
          case Dir.South:
            return (current.x, current.y - 1);
          case Dir.West:
            return (current.x - 1, current.y);
          case Dir.North:
            return (current.x, current.y + 1);
        }

        throw new ArgumentOutOfRangeException();
      }

      public enum Dir
      {
        East,
        South,
        West,
        North
      }
    }
  }
}
