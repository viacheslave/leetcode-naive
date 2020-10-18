using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/di-string-match/
  ///    Submission: https://leetcode.com/submissions/detail/238335186/
  /// </summary>
  internal class P0942
  {
    public class Solution
    {
      public int[] DiStringMatch(string S)
      {
        var res = new int[S.Length + 1];

        int min = 0;
        int max = 0;

        res[0] = 0;

        for (var i = 0; i < S.Length; i++)
        {
          if (S[i] == 'D')
          {
            res[i + 1] = min - 1;
            min--;
          }

          if (S[i] == 'I')
          {
            res[i + 1] = max + 1;
            max++;
          }
        }

        var inc = 0 - min;
        for (var i = 0; i < res.Length; i++)
          res[i] += inc;

        return res;
      }
    }
  }
}
