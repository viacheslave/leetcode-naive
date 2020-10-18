using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reordered-power-of-2/
  ///    Submission: https://leetcode.com/submissions/detail/235888390/
  /// </summary>
  internal class P0869
  {
    public class Solution
    {
      public bool ReorderedPowerOf2(int N)
      {
        var hs = new HashSet<string>(
            Enumerable.Range(0, 31)
                .Select(_ => new string(Math.Pow(2, _).ToString().OrderBy(a => a).ToArray()))
        );

        return hs.Contains(new string(N.ToString().OrderBy(a => a).ToArray()));
      }
    }
  }
}
