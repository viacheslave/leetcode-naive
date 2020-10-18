using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-string-chain/
  ///    Submission: https://leetcode.com/submissions/detail/243282116/
  /// </summary>
  internal class P1048
  {
    public class Solution
    {
      int max = 0;

      public int LongestStrChain(string[] words)
      {
        var maps = words.GroupBy(w => w.Length).ToDictionary(w => w.Key, w => new HashSet<string>(w));

        foreach (var word in words)
        {
          Traverse(maps, word, 1);
        }

        return max;
      }

      private void Traverse(Dictionary<int, HashSet<string>> maps, string word, int length)
      {
        var candidates = GetCandidates(maps, word);

        if (candidates.Count == 0)
        {
          max = Math.Max(max, length);
          return;
        }

        foreach (var candidate in candidates)
        {
          Traverse(maps, candidate, length + 1);
        }
      }

      private List<string> GetCandidates(Dictionary<int, HashSet<string>> maps, string word)
      {
        var result = new List<string>();

        if (!maps.ContainsKey(word.Length + 1))
          return result;

        foreach (var candidate in maps[word.Length + 1])
        {
          var hit = false;
          var fits = true;

          for (int i = 0; i < word.Length; i++)
          {
            if (!hit && word[i] != candidate[i])
            {
              hit = true;
              i--;
              continue;
            }

            if (hit)
            {
              if (word[i] == candidate[i + 1])
                continue;
            }
            else
            {
              if (word[i] == candidate[i])
                continue;
            }

            fits = false;
            break;
          }

          if (fits)
            result.Add(candidate);
        }
        return result;
      }
    }
  }
}
