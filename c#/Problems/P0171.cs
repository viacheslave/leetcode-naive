using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/excel-sheet-column-number/
  ///    Submission: https://leetcode.com/submissions/detail/228433429/
  /// </summary>
  internal class P0171
  {
    public class Solution
    {
      public int TitleToNumber(string s)
      {
        if (s.Length == 0)
          return 0;

        int sum = 0;
        for (var i = 0; i < s.Length; i++)
        {
          var ch = s[i];
          var power = s.Length - i;

          sum += ((int)ch - 65 + 1) * (int)Math.Pow(26, power - 1);
        }

        return sum;
      }
    }
  }
}
