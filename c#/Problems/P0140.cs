using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/word-break-ii/
  ///    Submission: https://leetcode.com/submissions/detail/416415137/
  /// </summary>
  internal class P0140
  {
    public class Solution
    {
      public IList<string> WordBreak(string s, IList<string> wordDict)
      {
        var wordCh = wordDict.SelectMany(x => x).Distinct().ToHashSet();
        var sCh = s.Select(x => x).Distinct().ToHashSet();

        sCh.ExceptWith(wordCh);
        if (sCh.Count > 0)
          return new List<string>();

        var ans = new HashSet<string>[s.Length + 1];
        var span = s.AsSpan();

        for (var i = 0; i <= s.Length; i++)
          ans[i] = new HashSet<string>();

        for (var i = 0; i < s.Length; i++)
        {
          if (i == 0)
          {
            DP(s, "", wordDict, ans, span, i);
            continue;
          }

          foreach (var bucket in ans[i])
            DP(s, bucket + " ", wordDict, ans, span, i);
        }

        return ans[s.Length].ToList();
      }

      private static void DP(string s, string bucket, IList<string> wordDict, HashSet<string>[] ans, ReadOnlySpan<char> span, int i)
      {
        foreach (var word in wordDict)
        {
          if (i + word.Length > s.Length)
            continue;

          var slice = span.Slice(i, word.Length);
          if (slice.Equals(word, StringComparison.OrdinalIgnoreCase))
          {
            ans[i + word.Length].Add(bucket + word);
          }
        }
      }
    }
  }
}
