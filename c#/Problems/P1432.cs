using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/max-difference-you-can-get-from-changing-an-integer/
  ///    Submission: https://leetcode.com/submissions/detail/344071017/
  /// </summary>
  internal class P1432
  {
    public class Solution
    {
      public int MaxDiff(int num)
      {
        var s = num.ToString();

        var sb = new StringBuilder(s);

        for (var i = 0; i < s.Length; i++)
        {
          if (sb[i] == '9')
            continue;

          var ch = sb[i];
          sb.Replace(ch, '9');

          break;
        }

        var max = int.Parse(sb.ToString());

        sb = new StringBuilder(s);

        for (var i = 0; i < s.Length; i++)
        {
          if (i == 0 && sb[i] == '1')
            continue;

          if (i > 0 && sb[i] == '0')
            continue;

          var original = sb.ToString();

          var ch = sb[i];
          sb.Replace(ch, i == 0 ? '1' : '0');

          if (sb[0] == '0')
          {
            sb = new StringBuilder(original);
            continue;
          }

          break;
        }

        var min = int.Parse(sb.ToString());

        return Math.Abs(max - min);
      }
    }
  }
}
