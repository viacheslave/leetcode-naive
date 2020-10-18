using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/rank-transform-of-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/299284946/
  /// </summary>
  internal class P1331
  {
    public class Solution
    {
      public int[] ArrayRankTransform(int[] arr)
      {
        var sorted = arr.Distinct().ToList();
        sorted.Sort();
        var map = sorted.Select((el, i) => (el, i + 1)).ToDictionary(x => x.Item1, x => x.Item2);

        return arr.Select(x => map[x]).ToArray();
      }
    }
  }
}
