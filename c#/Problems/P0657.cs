using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/robot-return-to-origin/
  ///    Submission: https://leetcode.com/submissions/detail/234415945/
  /// </summary>
  internal class P0657
  {
    public class Solution
    {
      public bool JudgeCircle(string moves)
      {
        int row = 0, col = 0;

        foreach (var ch in moves)
        {
          switch (ch)
          {
            case 'L': row++; break;
            case 'R': row--; break;
            case 'U': col++; break;
            case 'D': col--; break;
          }
        }

        return row == 0 && col == 0;
      }
    }
  }
}
