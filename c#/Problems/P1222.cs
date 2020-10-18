using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/queens-that-can-attack-the-king/
  ///    Submission: https://leetcode.com/submissions/detail/278253321/
  /// </summary>
  internal class P1222
  {
    public class Solution
    {
      public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
      {
        var queensSet = new HashSet<(int, int)>();
        foreach (var queen in queens)
          queensSet.Add((queen[0], queen[1]));

        var ans = new List<IList<int>>();

        for (var col = king[1] - 1; col >= 0; col--)
          if (queensSet.Contains((king[0], col))) { ans.Add(new List<int> { king[0], col }); break; }

        for (var col = king[1] + 1; col <= 8; col++)
          if (queensSet.Contains((king[0], col))) { ans.Add(new List<int> { king[0], col }); break; }

        for (var row = king[0] - 1; row >= 0; row--)
          if (queensSet.Contains((row, king[1]))) { ans.Add(new List<int> { row, king[1] }); break; }

        for (var row = king[0] + 1; row <= 8; row++)
          if (queensSet.Contains((row, king[1]))) { ans.Add(new List<int> { row, king[1] }); break; }

        for (int col = king[1] - 1, row = king[0] - 1; col >= 0; col--, row--)
          if (queensSet.Contains((row, col))) { ans.Add(new List<int> { row, col }); break; }

        for (int col = king[1] - 1, row = king[0] + 1; col >= 0; col--, row++)
          if (queensSet.Contains((row, col))) { ans.Add(new List<int> { row, col }); break; }

        for (int col = king[1] + 1, row = king[0] + 1; col < 8; col++, row++)
          if (queensSet.Contains((row, col))) { ans.Add(new List<int> { row, col }); break; }

        for (int col = king[1] + 1, row = king[0] - 1; col < 8; col++, row--)
          if (queensSet.Contains((row, col))) { ans.Add(new List<int> { row, col }); break; }

        return ans;
      }
    }
  }
}
