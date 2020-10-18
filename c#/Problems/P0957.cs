using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/prison-cells-after-n-days/
  ///    Submission: https://leetcode.com/submissions/detail/242757249/
  /// </summary>
  internal class P0957
  {
    public class Solution
    {
      public int[] PrisonAfterNDays(int[] cells, int N)
      {
        if (N == 0)
          return cells;

        var repeated = new List<int>();
        var newCells = new int[8];

        while (true)
        {
          newCells = new int[8];

          for (int i = 1; i <= 6; i++)
            newCells[i] = (cells[i - 1] == cells[i + 1]) ? 1 : 0;

          var value = 0;
          for (int i = 0; i < 8; i++)
            if (newCells[i] == 1)
              value += (int)Math.Pow(2, 8 - i - 1);

          if (repeated.Contains(value))
            break;

          repeated.Add(value);
          cells = newCells;
        }

        var number = repeated[(N - 1) % repeated.Count];

        var index = 0;
        while (index < 8)
        {
          newCells[8 - 1 - index] = (number % 2);
          number >>= 1;
          index++;
        }

        return newCells;
      }
    }
  }
}
