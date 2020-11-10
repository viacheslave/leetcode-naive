using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/prefix-and-suffix-search/
  ///    Submission: https://leetcode.com/submissions/detail/418802271/
  /// </summary>
  internal class P0745
  {
    public class WordFilter
    {
      private readonly Dictionary<string, List<int>> _wordsMap = new Dictionary<string, List<int>>();
      private readonly Trie<char> _trie = new Trie<char>();

      private Dictionary<(string, string), int> _mem = new Dictionary<(string, string), int>();

      public WordFilter(string[] words)
      {
        _wordsMap = words
          .Select((w, i) => (w, i))
          .GroupBy(_ => _.w)
          .ToDictionary(_ => _.Key, _ => _.Select(__ => __.i).OrderBy(c => c).ToList());

        foreach (var word in words)
        {
          var sb = new StringBuilder(word);
          sb.Insert(0, '#');

          for (var i = word.Length - 1; i >= 0; i--)
          {
            sb.Insert(0, word[i]);
            _trie.Add(sb.ToString());
          }
        }
      }

      public int F(string prefix, string suffix)
      {
        if (_mem.ContainsKey((prefix, suffix)))
          return _mem[(prefix, suffix)];

        var search = suffix + "#" + prefix;
        var current = _trie.Root;

        foreach (var ch in search)
        {
          if (current.Nodes.ContainsKey(ch))
            current = current.Nodes[ch];
          else
            return -1;
        }

        var ans = new List<string>();
        DFS(current, new StringBuilder(prefix), ans);

        var res = ans.SelectMany(x => _wordsMap[x]).Max();
        _mem[(prefix, suffix)] = res;

        return res;
      }

      private void DFS(TrieNode<char> current, StringBuilder sb, List<string> ans)
      {
        if (current.IsEnd)
          ans.Add(sb.ToString());

        foreach (var node in current.Nodes)
        {
          sb.Append(node.Key);
          DFS(node.Value, sb, ans);
          sb.Remove(sb.Length - 1, 1);
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
