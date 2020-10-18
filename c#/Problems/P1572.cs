using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/matrix-diagonal-sum/
  ///    Submission: https://leetcode.com/submissions/detail/391937433/
  /// </summary>
  internal class P1572
  {
    public class Solution
    {
      public int DiagonalSum(int[][] mat)
      {
        var ans = 0;

        for (var i = 0; i < mat.Length; i++)
        {
          ans += mat[i][mat.Length - 1 - i];
          ans += mat[i][i];

          if (i == mat.Length - 1 - i)
            ans -= mat[i][i];
        }

        return ans;
      }
    }
  }
}
