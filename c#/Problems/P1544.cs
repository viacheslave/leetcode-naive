using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/make-the-string-great/
  ///    Submission: https://leetcode.com/submissions/detail/387671789/
  /// </summary>
  internal class P1544
  {
    public class Solution
    {
      public string MakeGood(string s)
      {
        var sb = new StringBuilder(s);

        var index = 0;
        var indexes = new List<int>();

        do
        {
          indexes.Clear();
          index = 0;

          while (index <= sb.Length - 2)
          {
            if (Math.Abs(sb[index] - sb[index + 1]) == 32)
            {
              indexes.AddRange(new int[] { index, index + 1 });
              index += 2;
            }
            else
            {
              index++;
            }
          }

          foreach (var i in indexes.OrderByDescending(b => b))
            sb.Remove(i, 1);
        }
        while (indexes.Count > 0);

        return sb.ToString();
      }
    }
  }
}
