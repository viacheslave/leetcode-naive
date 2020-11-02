using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/word-search-ii/
  ///    Submission: https://leetcode.com/submissions/detail/415921855/
  /// </summary>
  internal class P0212
  {
    public class Solution
    {
      public IList<string> FindWords(char[][] board, string[] words)
      {
        var wordset = words.ToHashSet();
        var trie = new Trie<char>();
        var ans = new List<string>();

        foreach (var w in wordset)
          trie.Add(w);

        var visited = new HashSet<(int i, int j)>();
        var sb = new StringBuilder();
        var node = trie.Root;

        DFSTrie(board, (-1, -1), node, wordset, visited, sb);

        var ansSet = words.ToHashSet();
        ansSet.ExceptWith(wordset);

        return ansSet.ToList();
      }

      private void DFSTrie(
        char[][] board,
        (int i, int j) p,
        Trie<char>.TrieNode node,
        HashSet<string> wordset,
        HashSet<(int i, int j)> visited,
        StringBuilder sb)
      {
        if (p != (-1, -1))
          sb.Append(board[p.i][p.j]);

        if (node.IsEnd)
          wordset.Remove(sb.ToString());

        visited.Add(p);

        var neighbours = GetNeighbours(board, p, visited);

        foreach (var np in neighbours)
        {
          if (node.Nodes.ContainsKey(board[np.i][np.j]))
          {
            var child = node.Nodes[board[np.i][np.j]];
            DFSTrie(board, np, child, wordset, visited, sb);
          }
        }

        visited.Remove(p);

        if (p != (-1, -1))
          sb.Remove(sb.Length - 1, 1);
      }

      private List<(int i, int j)> GetNeighbours(char[][] board, (int i, int j) p, HashSet<(int i, int j)> visited)
      {
        var ans = new List<(int, int)>();

        if (p == (-1, -1))
        {
          for (var i = 0; i < board.Length; i++)
            for (var j = 0; j < board[0].Length; j++)
              ans.Add((i, j));

          return ans;
        }

        foreach (var pp in new[] { (p.i - 1, p.j), (p.i + 1, p.j), (p.i, p.j + 1), (p.i, p.j - 1) })
          if (pp.Item1 >= 0 && pp.Item2 >= 0 && pp.Item1 < board.Length && pp.Item2 < board[0].Length)
            if (!visited.Contains(pp))
              ans.Add(pp);

        return ans;
      }

      public class Trie<T>
      {
        public class TrieNode
        {
          public T Value { get; }

          public bool IsEnd { get; private set; }

          public Dictionary<T, TrieNode> Nodes => _nodes;

          private Dictionary<T, TrieNode> _nodes { get; } = new Dictionary<T, TrieNode>();

          public TrieNode(T value)
          {
            Value = value;
          }

          public bool SetEnd() => IsEnd = true;

          public TrieNode Add(T value)
          {
            if (_nodes.ContainsKey(value))
              return _nodes[value];

            var node = new TrieNode(value);
            _nodes[value] = node;

            return node;
          }
        }

        public TrieNode Root { get; } = new TrieNode(default);

        public void Add(IEnumerable<T> seq)
        {
          var current = Root;

          foreach (var element in seq)
            current = current.Add(element);

          current.SetEnd();
        }
      }
    }
  }
}
