using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-swaps-to-make-the-binary-string-alternating/
  ///    Submission: https://leetcode.com/submissions/detail/494103192/
  /// </summary>
  internal class P1864
  {
    public class Solution
    {
      public int MinSwaps(string s)
      {
        var ones = s.Count(x => x == '1');
        var zeros = s.Count(x => x == '0');

        if (Math.Abs(ones - zeros) > 1)
          return -1;

        // try 10101...
        var v1 = int.MaxValue;
        if (ones >= zeros)
          v1 = Get1(s.ToCharArray(), 0);

        // try 010101....
        var v2 = int.MaxValue;
        if (ones <= zeros)
          v2 = Get1(s.ToCharArray(), 1);

        return Math.Min(v1, v2);
      }

      private static int Get1(char[] arr, int mod)
      {
        var ans = 0;

        for (var i = 0; i < arr.Length; i++)
        {
          var cur = arr[i];
          var exp = i % 2 == mod ? '1' : '0';

          if (cur == exp)
            continue;

          ans++;

          var best = -1;

          for (var j = i + 1; j < arr.Length; j++)
          {
            var cur2 = arr[j];
            var exp2 = j % 2 == mod ? '1' : '0';

            if (cur2 == exp2 || cur == cur2)
              continue;

            best = j;
            break;
          }

          // arr is ok
          if (best == -1)
            return ans;

          arr[i] = exp;
          arr[best] = cur;
        }

        return ans;
      }
    }
  }
}
