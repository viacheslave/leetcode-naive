using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/robot-bounded-in-circle/
  ///    Submission: https://leetcode.com/submissions/detail/238010346/
  /// </summary>
  internal class P1041
  {
    public class Solution
    {
      public bool IsRobotBounded(string instructions)
      {
        var dir = Dir.North;
        var pos = (0, 0);

        foreach (var ins in instructions)
        {
          if (ins == 'G')
          {
            switch (dir)
            {
              case Dir.North:
                pos = (pos.Item1, pos.Item2 + 1);
                break;
              case Dir.East:
                pos = (pos.Item1 + 1, pos.Item2);
                break;
              case Dir.South:
                pos = (pos.Item1, pos.Item2 - 1);
                break;
              case Dir.West:
                pos = (pos.Item1 - 1, pos.Item2);
                break;
            }
          }

          if (ins == 'L')
          {
            switch (dir)
            {
              case Dir.North:
                dir = Dir.West;
                break;
              case Dir.East:
                dir = Dir.North;
                break;
              case Dir.South:
                dir = Dir.East;
                break;
              case Dir.West:
                dir = Dir.South;
                break;
            }
          }

          if (ins == 'R')
          {
            switch (dir)
            {
              case Dir.North:
                dir = Dir.East;
                break;
              case Dir.East:
                dir = Dir.South;
                break;
              case Dir.South:
                dir = Dir.West;
                break;
              case Dir.West:
                dir = Dir.North;
                break;
            }
          }
        }

        return (pos.Item1 == 0 && pos.Item2 == 0) || dir != Dir.North;
      }

      public enum Dir
      {
        North,
        East,
        South,
        West
      }
    }
  }
}
