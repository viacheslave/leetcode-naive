using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-and-replace-pattern/
  ///    Submission: https://leetcode.com/submissions/detail/239105612/
  /// </summary>
  internal class P0890
  {
    public class Solution
    {
      public IList<string> FindAndReplacePattern(string[] words, string pattern)
      {
        var res = new List<string>();

        foreach (var word in words)
        {
          var one = new Dictionary<char, char>();
          var two = new Dictionary<char, char>();

          var matches = true;

          for (var i = 0; i < pattern.Length; i++)
          {
            if (one.ContainsKey(word[i]) && one[word[i]] != pattern[i])
            {
              matches = false;
              break;
            }

            if (two.ContainsKey(pattern[i]) && two[pattern[i]] != word[i])
            {
              matches = false;
              break;
            }

            one[word[i]] = pattern[i];
            two[pattern[i]] = word[i];
          }

          if (one.Count != two.Count)
            continue;

          foreach (var item in one)
          {
            if (!two.ContainsKey(item.Value) || two[item.Value] != item.Key)
            {
              matches = false;
              break;
            }
          }

          if (matches)
            res.Add(word);
        }

        return res;
      }
    }
  }
}
