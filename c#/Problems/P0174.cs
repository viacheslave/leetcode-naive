using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/dungeon-game/
  ///    Submission: https://leetcode.com/submissions/detail/422414586/
  /// </summary>
  internal class P0174
  {
    public class Solution
    {
      public int CalculateMinimumHP(int[][] dungeon)
      {
        var lower = 1;
        var upper = 1;

        // get upper
        for (; upper < int.MaxValue; upper *= 2)
        {
          var can = CanWalk(upper, dungeon);
          if (can)
            break;
        }

        if (upper == 1)
          return 1;

        // binary search
        while (true)
        {
          if (upper - lower == 1)
          {
            var lvalue = CanWalk(lower, dungeon);
            return (lvalue) ? lower : upper;
          }

          var mid = (lower + upper) / 2;
          var mvalue = CanWalk(mid, dungeon);

          if (mvalue)
            upper = mid;
          else
            lower = mid;
        }
      }

      private bool CanWalk(int health, (int row, int col) p, int[][] dungeon, int[,] dpp)
      {
        health += dungeon[p.row][p.col];
        if (health <= 0)
          return false;

        if (p.row == dungeon.Length - 1 && p.col == dungeon[0].Length - 1)
          return health > 0;

        if (dpp[p.row, p.col] != int.MinValue && health <= dpp[p.row, p.col])
          return false;

        dpp[p.row, p.col] = health;

        var down = (p.row + 1, p.col);
        var right = (p.row, p.col + 1);

        if (IsPointOk(dungeon, down) && IsPointOk(dungeon, right))
          return
            CanWalk(health, down, dungeon, dpp) ||
            CanWalk(health, right, dungeon, dpp);
        else if (IsPointOk(dungeon, down))
          return CanWalk(health, down, dungeon, dpp);
        else
          return CanWalk(health, right, dungeon, dpp);
      }

      private bool IsPointOk(int[][] dungeon, (int row, int col) p)
      {
        return !(p.row < 0 || p.col < 0 || p.row >= dungeon.Length || p.col >= dungeon[0].Length);
      }

      public bool CanWalk(int health, int[][] dungeon)
      {
        var dpp = new int[dungeon.Length, dungeon[0].Length];
        return CanWalk(health, (0, 0), dungeon, dpp);
      }
    }
  }
}
