using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-all-anagrams-in-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/232014177/
  /// </summary>
  internal class P0438
  {
    public class Solution
    {
      public IList<int> FindAnagrams(string s, string p)
      {
        var pd = new Dictionary<char, int>();
        foreach (var ch in p)
        {
          if (!pd.ContainsKey(ch))
            pd[ch] = 0;
          pd[ch]++;
        }

        if (p.Length > s.Length)
          return new List<int>();

        var window = new Dictionary<char, int>();
        for (var i = 0; i < p.Length; i++)
        {
          if (!window.ContainsKey(s[i]))
            window[s[i]] = 0;
          window[s[i]]++;
        }

        var start = 0;
        var end = p.Length - 1;

        var result = new List<int>();

        while (end < s.Length)
        {
          var fits = Fits(pd, window);
          if (fits)
            result.Add(start);

          if (end != s.Length - 1)
          {
            window[s[start]]--;
            if (window[s[start]] == 0)
              window.Remove(s[start]);

            if (!window.ContainsKey(s[end + 1]))
              window[s[end + 1]] = 0;

            window[s[end + 1]]++;
          }

          start++;
          end++;
        }

        return result;
      }

      private bool Fits(Dictionary<char, int> pd, Dictionary<char, int> window)
      {
        if (pd.Count != window.Count)
          return false;

        foreach (var pch in pd)
        {
          if (!window.ContainsKey(pch.Key))
            return false;

          if (window[pch.Key] != pch.Value)
            return false;
        }

        return true;
      }
    }
  }
}
