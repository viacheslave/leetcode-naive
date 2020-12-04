using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flip-columns-for-maximum-number-of-equal-rows/
  ///    Submission: https://leetcode.com/submissions/detail/427100432/
  /// </summary>
  internal class P1072
  {
    public class Solution
    {
      public int MaxEqualRowsAfterFlips(int[][] matrix)
      {
        var ans = 0;
        var map2 = matrix.Select(x => string.Join("", x.Select(a => a))).ToList();

        for (var i = 0; i < matrix.Length; i++)
        {
          var option1 = map2[i];
          var option2 = new string(map2[i].Select(x => x == '0' ? '1' : '0').ToArray());

          ans = Math.Max(ans, map2.Where(item => item == option1 || item == option2).Count());
        }

        return ans;
      }
    }
  }
}
