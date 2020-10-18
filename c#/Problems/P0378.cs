using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/235715513/
  /// </summary>
  internal class P0378
  {
    public class Solution
    {
      public int KthSmallest(int[][] matrix, int k)
      {
        var sd = new SortedDictionary<int, int>();
        for (var i = 0; i < matrix.Length; i++)
        {
          for (var j = 0; j < matrix.Length; j++)
          {
            if (!sd.ContainsKey(matrix[i][j]))
              sd[matrix[i][j]] = 0;

            sd[matrix[i][j]]++;
          }
        }

        var start = 0;
        var end = 0;

        foreach (var item in sd)
        {
          start = end + 1;
          end = start + item.Value - 1;

          if (start <= k && k <= end)
            return item.Key;
        }

        return -1;
      }
    }
  }
}
