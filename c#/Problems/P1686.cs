using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/stone-game-vi/
  ///    Submission: https://leetcode.com/submissions/detail/429935857/
  /// </summary>
  internal class P1686
  {
    public class Solution
    {
      public int StoneGameVI(int[] aliceValues, int[] bobValues)
      {
        var sorted = Enumerable.Range(0, aliceValues.Length)
          .Select(e => (aliceValues[e], bobValues[e]))
          .OrderByDescending(e => e.Item1 + e.Item2)
          .ToList();

        var alice = 0;
        var bob = 0;

        for (var i = 0; i < sorted.Count; i++)
          if (i % 2 == 0)
            alice += sorted[i].Item1;
          else
            bob += sorted[i].Item2;

        return alice.CompareTo(bob);
      }
    }
  }
}
