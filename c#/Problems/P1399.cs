using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-largest-group/
  ///    Submission: https://leetcode.com/submissions/detail/321330747/
  /// </summary>
  internal class P1399
  {
    public class Solution
    {
      public int CountLargestGroup(int n)
      {
        var digitSumToCount = Enumerable.Range(1, n)
          .GroupBy(x => x.ToString().ToCharArray().Select(r => int.Parse(r.ToString())).Sum())
          .OrderBy(x => x.Key)
          .ToDictionary(x => x.Key, x => x.Count());

        var max = digitSumToCount.Values.Max();

        return digitSumToCount.Count(x => x.Value == max);
      }
    }
  }
}
