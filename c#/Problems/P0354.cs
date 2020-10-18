using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/russian-doll-envelopes/
  ///    Submission: https://leetcode.com/submissions/detail/250229100/
  /// </summary>
  internal class P0354
  {
    public class Solution
    {
      public int MaxEnvelopes(int[][] envelopes)
      {
        envelopes = envelopes.OrderBy(_ => _[0]).ThenBy(_ => _[1]).ToArray();

        if (envelopes.Length == 0)
          return 0;

        var lis = new Dictionary<int, int>();

        for (int i = 0; i < envelopes.Length; i++)
        {
          var maxLength = 1;

          for (int j = 0; j < i; j++)
          {
            if (envelopes[j][0] < envelopes[i][0] && envelopes[j][1] < envelopes[i][1])
            {
              maxLength = Math.Max(maxLength, lis[j] + 1);
            }
          }

          lis[i] = maxLength;
        }

        return lis.Max(_ => _.Value);
      }
    }
  }
}
