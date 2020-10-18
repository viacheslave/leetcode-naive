using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/implement-trie-prefix-tree/
  ///    Submission: https://leetcode.com/submissions/detail/239725159/
  /// </summary>
  internal class P0208
  {
    public class Solution
    {
      public class Trie
      {
        HashSet<string> primary;
        HashSet<string> secondary;

        /** Initialize your data structure here. */
        public Trie()
        {
          primary = new HashSet<string>();
          secondary = new HashSet<string>();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
          primary.Add(word);

          var sb = new StringBuilder(word);
          while (sb.Length > 0)
          {
            secondary.Add(sb.ToString());
            sb.Remove(sb.Length - 1, 1);
          }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
          return primary.Contains(word);
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
          return secondary.Contains(prefix);
        }
      }
    }
  }
}
