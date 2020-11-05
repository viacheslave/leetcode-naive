using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/soup-servings/
  ///    Submission: https://leetcode.com/submissions/detail/417031054/
  /// </summary>
  internal class P0808
  {
    public class Solution
    {
      public double SoupServings(int N)
      {
        if (N == 0)
          return 0.5;

        if (N <= 50)
          return 0.625;

        if (N >= 5000)
          return 1;

        var dp = new Dictionary<int, Dictionary<(int a, int b), double>>();
        dp[0] = new Dictionary<(int a, int b), double>() { [(N, N)] = 1 };

        for (var i = 1; ; i++)
        {
          var prev = dp[i - 1];
          if (prev.Count == 0)
            break;

          var bag = new List<(int, int, double)>();

          foreach (var entry in prev)
          {
            if (entry.Key.a <= 0 || entry.Key.b <= 0)
              continue;

            var prob = entry.Value * 0.25;

            bag.Add((a: entry.Key.a - 100, b: entry.Key.b, prob));
            bag.Add((a: entry.Key.a - 75, b: entry.Key.b - 25, prob));
            bag.Add((a: entry.Key.a - 50, b: entry.Key.b - 50, prob));
            bag.Add((a: entry.Key.a - 25, b: entry.Key.b - 75, prob));
          }

          dp[i] = bag
            .GroupBy(x => (x.Item1, x.Item2))
            .ToDictionary(x => x.Key, x => x.Sum(f => f.Item3));
        }

        var a = dp.SelectMany(e => e.Value).Where(c => c.Key.a <= 0 && c.Key.b > 0)
          .Sum(x => x.Value);

        var b = dp.SelectMany(e => e.Value).Where(c => c.Key.a <= 0 && c.Key.b <= 0)
          .Sum(x => x.Value);

        return a + b / 2;
      }
    }
  }
}
