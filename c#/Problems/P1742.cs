using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-number-of-balls-in-a-box/
  ///    Submission: https://leetcode.com/submissions/detail/450136425/
  /// </summary>
  internal class P1742
  {
    public class Solution
    {
      public int CountBalls(int lowLimit, int highLimit)
      {
        return Enumerable.Range(lowLimit, highLimit - lowLimit + 1)
          .Select(x => x.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).Sum())
          .GroupBy(x => x)
          .ToDictionary(x => x.Key, x => x.Count())
          .OrderByDescending(x => x.Value)
          .First()
          .Value;
      }
    }
  }
}
