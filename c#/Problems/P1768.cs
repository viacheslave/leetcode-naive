using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/merge-strings-alternately/
  ///    Submission: https://leetcode.com/submissions/detail/491366847/
  /// </summary>
  internal class P1768
  {
    public class Solution
    {
      public string MergeAlternately(string word1, string word2)
      {
        var ml = Math.Max(word1.Length, word2.Length);
        var ch = new List<char>();

        for (var i = 0; i < ml; ++i)
        {
          if (i < word1.Length)
            ch.Add(word1[i]);
          if (i < word2.Length)
            ch.Add(word2[i]);
        }

        return new string(ch.ToArray());
      }
    }
  }
}
