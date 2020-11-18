using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-matching-subsequences/
  ///    Submission: https://leetcode.com/submissions/detail/421619157/
  /// </summary>
  internal class P0792
  {
    public class Solution
    {
      public int NumMatchingSubseq(string S, string[] words)
      {
        var map = new Dictionary<string, bool>();
        var ans = 0;

        foreach (var word in words)
        {
          var sub = map.ContainsKey(word) ? map[word] : IsSubsequence(word, S);
          if (sub)
            ans++;

          map[word] = sub;
        }

        return ans;
      }

      public bool IsSubsequence(string s, string t)
      {
        var fi = 0;

        for (var i = 0; i < t.Length; i++)
        {
          if (s[fi] == t[i])
          {
            fi++;
            if (fi == s.Length)
              return true;
          }
        }

        return false;
      }
    }
  }
}
