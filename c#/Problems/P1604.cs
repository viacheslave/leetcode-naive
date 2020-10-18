using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/alert-using-same-key-card-three-or-more-times-in-a-one-hour-period/
  ///    Submission: https://leetcode.com/submissions/detail/404349465/
  /// </summary>
  internal class P1604
  {
    public class Solution
    {
      public IList<string> AlertNames(string[] keyName, string[] keyTime)
      {
        var people = new Dictionary<string, List<DateTime>>();

        for (int i = 0; i < keyName.Length; i++)
        {
          if (!people.ContainsKey(keyName[i]))
            people[keyName[i]] = new List<DateTime>();

          var parts = keyTime[i].Split(":");

          people[keyName[i]].Add(new DateTime(0001, 1, 1, int.Parse(parts[0]), int.Parse(parts[1]), 0));
        }

        var ans = new List<string>();

        foreach (var entry in people)
        {
          var times = entry.Value.OrderBy(x => x).ToList();

          if (times.Count < 3)
            continue;

          for (var i = 2; i < times.Count; i++)
          {
            var span = times[i] - times[i - 2];
            if (span.TotalMinutes <= 60)
            {
              ans.Add(entry.Key);
              break;
            }
          }
        }

        return ans.OrderBy(c => c).ToArray();
      }
    }
  }
}
