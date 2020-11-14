using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-substrings-that-differ-by-one-character/
  ///    Submission: https://leetcode.com/submissions/detail/420172694/
  /// </summary>
  internal class P1638
  {
    public class Solution
    {
      public int CountSubstrings(string s, string t)
      {
        var ss = new List<string>();
        var tt = new List<string>();

        for (var i = 0; i < s.Length; i++)
          for (var j = i; j < s.Length; j++)
            ss.Add(s.Substring(i, j - i + 1));

        for (var i = 0; i < t.Length; i++)
          for (var j = i; j < t.Length; j++)
            tt.Add(t.Substring(i, j - i + 1));

        var smap = ss.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var tmap = tt.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        var trie = new Trie<char>();
        foreach (var key in tmap.Keys)
          trie.Add(key);

        var ans = 0;

        foreach (var str in smap)
        {
          var matches = new List<string>();
          var current = new StringBuilder();

          Traverse(str.Key, -1, trie.Root, matches, current, false);

          ans += str.Value * matches.Select(m => tmap[m]).Sum();
        }

        return ans;
      }

      private void Traverse(string str, int pos, TrieNode<char> node, List<string> matches, StringBuilder current, bool changed)
      {
        if (pos == str.Length - 1)
        {
          if (node.IsEnd && changed)
            matches.Add(current.ToString());

          return;
        }

        pos++;
        var ch = str[pos];

        if (changed)
        {
          if (node.Nodes.ContainsKey(str[pos]))
          {
            current.Append(ch);
            Traverse(str, pos, node.Nodes[ch], matches, current, changed);

            current.Remove(current.Length - 1, 1);
          }
        }
        else
        {
          foreach (var child in node.Nodes)
          {
            current.Append(child.Key);

            if (child.Key == ch)
              Traverse(str, pos, node.Nodes[child.Key], matches, current, changed);
            else
              Traverse(str, pos, node.Nodes[child.Key], matches, current, true);

            current.Remove(current.Length - 1, 1);
          }
        }
      }

      public class Trie<T>
      {
        public TrieNode<T> Root { get; } = new TrieNode<T>(default);

        public void Add(IEnumerable<T> seq)
        {
          var current = Root;

          foreach (var element in seq)
            current = current.Add(element);

          current.SetEnd();
        }
      }

      public sealed class TrieNode<T>
      {
        public T Value { get; }

        public bool IsEnd { get; private set; }

        public Dictionary<T, TrieNode<T>> Nodes { get; } = new Dictionary<T, TrieNode<T>>();

        public TrieNode(T value)
        {
          Value = value;
        }

        public void SetEnd() => IsEnd = true;

        public TrieNode<T> Add(T value)
        {
          if (Nodes.ContainsKey(value))
            return Nodes[value];

          var node = new TrieNode<T>(value);
          Nodes[value] = node;

          return node;
        }
      }
    }
  }
}
