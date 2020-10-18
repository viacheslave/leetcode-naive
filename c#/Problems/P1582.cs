using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/special-positions-in-a-binary-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/395059638/
  /// </summary>
  internal class P1582
  {
    public class Solution
    {
      public int NumSpecial(int[][] mat)
      {
        var rowsMap = new Dictionary<int, int>();
        var colsMap = new Dictionary<int, int>();

        for (var i = 0; i < mat.Length; i++)
        {
          var count = 0;
          for (var j = 0; j < mat[0].Length; j++)
          {
            if (mat[i][j] == 1)
            {
              count++;
              rowsMap[i] = j;
            }
          }

          if (count != 1)
            rowsMap.Remove(i);
        }

        for (var j = 0; j < mat[0].Length; j++)
        {
          var count = 0;
          for (var i = 0; i < mat.Length; i++)
          {
            if (mat[i][j] == 1)
            {
              count++;
              colsMap[j] = i;
            }
          }

          if (count != 1)
            colsMap.Remove(j);
        }

        var ans = 0;

        foreach (var rowItem in rowsMap)
        {
          foreach (var colItem in colsMap)
          {
            if (rowItem.Value == colItem.Key && rowItem.Key == colItem.Value)
              ans++;
          }
        }

        return ans;
      }
    }
  }
}
