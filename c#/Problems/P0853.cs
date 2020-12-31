using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/car-fleet/
  ///    Submission: https://leetcode.com/submissions/detail/436840594/
  /// </summary>
  internal class P0853
  {
    public class Solution
    {
      public int CarFleet(int target, int[] position, int[] speed)
      {
        if (position.Length == 0)
          return 0;

        // sort by closest position to target
        var ps = Enumerable.Range(0, position.Length)
          .Select(i => (d: target - position[i], s: speed[i]))
          .OrderBy(a => a.d)
          .ToArray();

        var ans = 1;

        // arrival time
        var time = 1.0 * ps[0].d / ps[0].s;

        for (var i = 1; i < ps.Length; i++)
        {
          var t = 1.0 * ps[i].d / ps[i].s;

          // if next car arrival time is less than prev car arrival time
          // then it's the same fleet
          if (t <= time)
            continue;

          // otherwise we update current arrival time
          // and this is a new fleet
          time = t;
          ans++;
        }

        return ans;
      }
    }
  }
}
