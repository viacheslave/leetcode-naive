using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/299511859/
  /// </summary>
  internal class P1341
  {
    public class Solution
    {
      public int[] KWeakestRows(int[][] mat, int k)
      {
        return mat.Select((row, index) => (index, row.Count(r => r == 1)))
            .OrderBy(x => x.Item2)
            .ThenBy(x => x.index)
            .Take(k)
            .Select(x => x.index)
            .ToArray();
      }
    }
  }
}
