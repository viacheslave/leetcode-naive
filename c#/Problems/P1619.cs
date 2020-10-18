using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///   Problem: https://leetcode.com/problems/mean-of-array-after-removing-some-elements/
  ///   Submission: https://leetcode.com/submissions/detail/409890434/
  /// </summary>
  internal class P1619
  {
    public class Solution
    {
      public double TrimMean(int[] arr)
      {
        var percentage = arr.Length / 20;
        var ar = arr
          .OrderBy(x => x)
          .Skip(percentage)
          .Take(arr.Length - percentage * 2)
          .ToList();

        return ar.Average();
      }
    }
  }
}
