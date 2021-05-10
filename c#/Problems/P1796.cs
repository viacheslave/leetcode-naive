using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/second-largest-digit-in-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/491299473/
  /// </summary>
  internal class P1796
  {
    public class Solution
    {
      public int SecondHighest(string s)
      {
        var list = s
          .Where(c => char.IsDigit(c))
          .Select(x => int.Parse(x.ToString()))
          .Distinct()
          .OrderByDescending(x => x)
          .ToList();

        return list.Count < 2 ? -1 : list[1];
      }
    }
  }
}
