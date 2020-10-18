using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/most-visited-sector-in-a-circular-track/
  ///    Submission: https://leetcode.com/submissions/detail/387104485/
  /// </summary>
  internal class P1560
  {
    public class Solution
    {
      public IList<int> MostVisited(int n, int[] rounds)
      {
        var visits = new Dictionary<int, int>();

        for (var i = 1; i <= n; i++)
          visits.Add(i, 0);

        var current = rounds[0];
        visits[current]++;

        for (var i = 1; i < rounds.Length; i++)
        {
          do
          {
            current++;
            if (current > n)
              current = (current % n);

            visits[current]++;
          }
          while (current != rounds[i]);
        }

        var maxVisits = visits.Max(c => c.Value);

        var keys = visits
            .Where(c => c.Value == maxVisits)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToList();

        return keys;
      }
    }
  }
}
