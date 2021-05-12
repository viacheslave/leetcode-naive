using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-substring-of-all-vowels-in-order/
  ///    Submission: https://leetcode.com/submissions/detail/492188861/
  /// </summary>
  internal class P1839
  {
    public class Solution
    {
      public int LongestBeautifulSubstring(string word)
      {
        var left = 0;

        if (word.Length < 5)
          return 0;

        var map = new Dictionary<char, int>() { [word[0]] = 1 };
        var ans = 0;

        for (var i = 1; i < word.Length; i++)
        {
          if (word[i] < word[i - 1])
          {
            map = new Dictionary<char, int>() { [word[i]] = 1 };
            left = i;
            continue;
          }

          if (map.ContainsKey(word[i]))
            map[word[i]]++;
          else
            map[word[i]] = 1;

          if (word[left] == 'a' && word[i] == 'u' && map.Count == 5)
            ans = Math.Max(ans, i - left + 1);
        }

        return ans;
      }
    }
  }
}
