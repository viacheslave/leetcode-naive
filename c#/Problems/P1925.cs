using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-square-sum-triples/
  ///    Submission: https://leetcode.com/submissions/detail/525481784/
  /// </summary>
  internal class P1925
  {
    public class Solution
    {
      public int CountTriples(int n)
      {
        var ans = 0;

        for (var i = 1; i <= n; i++)
          for (var j = 1; j <= n; j++)
            for (var k = 1; k <= n; k++)
              if (i * i + j * j == k * k)
                ans++;

        return ans;
      }
    }
  }
}
