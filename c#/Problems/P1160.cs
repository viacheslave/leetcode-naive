using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/
  ///    Submission: https://leetcode.com/submissions/detail/255325780/
  /// </summary>
  internal class P1160
  {
    public class Solution
    {
      public int CountCharacters(string[] words, string chars)
      {
        var ans = 0;
        var chmap = GetMap(chars);

        foreach (var word in words)
        {
          var wordmap = GetMap(word);
          if (IsValid(wordmap, chmap))
            ans += word.Length;
        }

        return ans;
      }

      private bool IsValid(Dictionary<char, int> wordmap, Dictionary<char, int> chmap)
      {
        foreach (var wordkvp in wordmap)
        {
          if (!chmap.ContainsKey(wordkvp.Key) || chmap[wordkvp.Key] < wordmap[wordkvp.Key])
            return false;
        }

        return true;
      }

      private Dictionary<char, int> GetMap(string chars)
      {
        var res = new Dictionary<char, int>();

        foreach (var ch in chars)
        {
          if (!res.ContainsKey(ch))
            res[ch] = 0;

          res[ch]++;
        }

        return res;
      }
    }
  }
}
