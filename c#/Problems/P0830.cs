using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/positions-of-large-groups
  ///    Submission: https://leetcode.com/submissions/detail/233820116/
  /// </summary>
  internal class P0830
  {
    public class Solution
    {
      public IList<IList<int>> LargeGroupPositions(string S)
      {
        var result = new List<IList<int>>();

        if (S.Length == 0)
          return result;

        var start = 0;
        var current = start;

        for (var i = 1; i < S.Length; i++)
        {
          var cur = S[i];
          var prev = S[i - 1];

          current = i;

          if (cur == prev)
          {
            continue;
          }
          else
          {
            if (current - 1 - start >= 2)
              result.Add(new List<int> { start, current - 1 });

            start = i;
            current = i;
          }
        }

        if (current - start >= 2)
          result.Add(new List<int> { start, current });

        return result;
      }
    }
  }
}
