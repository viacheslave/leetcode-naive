using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-distance-to-type-a-word-using-two-fingers/
  ///    Submission: https://leetcode.com/submissions/detail/422682882/
  /// </summary>
  internal class P1320
  {
    public class Solution
    {
      public int MinimumDistance(string word)
      {
        var dp = new Dictionary<(char f1, char f2), int>[word.Length + 1];
        var t = new List<(char f1, char f2)>();

        foreach (var ch in word.Distinct())
          foreach (var ch2 in word.Distinct())
            t.Add((ch, ch2));

        var map = GetMap();

        dp[0] = t.ToDictionary(x => x, _ => 0);

        for (var i = 1; i < word.Length + 1; ++i)
        {
          dp[i] = new Dictionary<(char f1, char f2), int>();

          var ch = word[i - 1];

          foreach (var entry in dp[i - 1])
          {
            dp[i][(ch, entry.Key.f2)] = dp[i].ContainsKey((ch, entry.Key.f2))
              ? Math.Min(dp[i][(ch, entry.Key.f2)], entry.Value + Dist(map, ch, entry.Key.f1))
              : entry.Value + Dist(map, ch, entry.Key.f1);

            dp[i][(entry.Key.f1, ch)] = dp[i].ContainsKey((entry.Key.f1, ch))
              ? Math.Min(dp[i][(entry.Key.f1, ch)], entry.Value + Dist(map, ch, entry.Key.f2))
              : entry.Value + Dist(map, ch, entry.Key.f2);
          }
        }

        return dp[word.Length].Min(c => c.Value);
      }

      private int Dist(Dictionary<char, (int i, int j)> map, char ch1, char ch2)
      {
        return Math.Abs(map[ch1].i - map[ch2].i) + Math.Abs(map[ch1].j - map[ch2].j);
      }

      private Dictionary<char, (int i, int j)> GetMap()
      {
        var map = new Dictionary<char, (int i, int j)>();

        for (var i = 0; i < 26; i++)
        {
          var ch = (char)(i + 65);
          map[ch] = (i: i / 6, j: i % 6);
        }

        return map;
      }
    }
  }
}
