using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/rank-teams-by-votes/
  ///    Submission: https://leetcode.com/submissions/detail/412955058/
  /// </summary>
  internal class P1366
  {
    public class Solution
    {
      public string RankTeams(string[] votes)
      {
        const int teams = 26;

        var ranks = new int[teams][];
        for (var i = 0; i < teams; i++)
          ranks[i] = new int[teams];


        foreach (var vote in votes)
        {
          for (var place = 0; place < vote.Length; place++)
          {
            var team = vote[place];
            ranks[team - 65][place]++;
          }
        }

        var ranksMap = ranks
          .Select((r, i) => (r, i))
          .Where(r => r.r.Any(v => v > 0))
          .ToDictionary(x => x.i, x => x.r);

        var ordered = ranksMap
          .Select((r, i) => (r, i))
          .OrderByDescending(x => x.r, new RanksComparer())
          .ToList();

        return string.Join("", ordered.Select(x => (char)(65 + x.r.Key)));
      }

      internal class RanksComparer : IComparer<KeyValuePair<int, int[]>>
      {
        public int Compare(KeyValuePair<int, int[]> x, KeyValuePair<int, int[]> y)
        {
          for (var i = 0; i < x.Value.Length; i++)
          {
            if (x.Value[i] < y.Value[i])
              return -1;
            if (x.Value[i] > y.Value[i])
              return 1;
          }

          return y.Key - x.Key;
        }
      }
    }
  }
}
