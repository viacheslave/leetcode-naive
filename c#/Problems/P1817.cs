using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/finding-the-users-active-minutes/
  ///    Submission: https://leetcode.com/submissions/detail/476324292/
  /// </summary>
  internal class P1817
  {
    public class Solution
    {
      public int[] FindingUsersActiveMinutes(int[][] logs, int k)
      {
        var map = new Dictionary<int, HashSet<int>>();

        foreach (var log in logs)
        {
          var userId = log[0];
          var time = log[1];

          if (!map.ContainsKey(userId))
            map[userId] = new HashSet<int>();

          map[userId].Add(time);
        }

        var cbl = map.GroupBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Count());
        var ans = new int[k];

        for (var j = 0; j < k; ++j)
        {
          var v = cbl.TryGetValue(j + 1, out var a);
          ans[j] = a;
        }

        return ans;
      }
    }
  }
}
