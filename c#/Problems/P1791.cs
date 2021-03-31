using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-center-of-star-graph/
  ///    Submission: https://leetcode.com/submissions/detail/470531170/
  /// </summary>
  internal class P1791
  {
    public class Solution
    {
      public int FindCenter(int[][] edges)
      {
        return edges
          .Take(2)
          .SelectMany(x => new int[] { x[0], x[1] })
          .GroupBy(c => c)
          .OrderByDescending(x => x.Count())
          .First().Key;
      }
    }
  }
    }
  }
}
