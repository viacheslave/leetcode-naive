using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/defuse-the-bomb/
  ///    Submission: https://leetcode.com/submissions/detail/420455970/
  /// </summary>
  internal class P1652
  {
    public class Solution
    {
      public int[] Decrypt(int[] code, int k)
      {
        var prefix = new int[code.Length + 1];

        for (var i = 0; i < code.Length; i++)
          prefix[i + 1] = prefix[i] + code[i];

        if (k == 0)
          return new int[code.Length];

        if (k > 0)
        {
          var ans = new int[code.Length];

          for (var i = 0; i < code.Length; i++)
          {
            ans[i] = i + k >= code.Length
              ? GetSum(prefix, i + 1, code.Length - 1) + GetSum(prefix, 0, (i + k) % code.Length)
              : GetSum(prefix, i + 1, i + k);
          }

          return ans;
        }
        else
        {
          var ans = new int[code.Length];

          for (var i = 0; i < code.Length; i++)
          {
            ans[i] = i + k < 0
              ? GetSum(prefix, 0, i - 1) + GetSum(prefix, (code.Length + i + k), code.Length - 1)
              : GetSum(prefix, i + k, i - 1);
          }

          return ans;
        }
      }

      private int GetSum(int[] prefix, int from, int to) => prefix[to + 1] - prefix[from];
    }
  }
}
