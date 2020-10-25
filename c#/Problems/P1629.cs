using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/slowest-key/
  ///    Submission: https://leetcode.com/submissions/detail/412907967/
  /// </summary>
  internal class P1629
  {
    public class Solution
    {
      public char SlowestKey(int[] releaseTimes, string keysPressed)
      {
        var data = Enumerable
         .Range(0, releaseTimes.Length)
         .Select(r => (time: releaseTimes[r] - (r == 0 ? 0 : releaseTimes[r - 1]), ch: keysPressed[r]))
         .ToList();

        var max = data.Max(x => x.time);

        return data.Where(x => x.time == max)
          .OrderBy(x => x.ch)
          .Select(x => x.ch)
          .Last();
      }
    }
  }
}
