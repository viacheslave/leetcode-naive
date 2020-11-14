using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Transactions;
using LeetCode.Naive;

namespace LeetCode.Naive
{
  class Program
  {
    static void Main(string[] args)
    {
      var root = new TreeNode(2);
      root.left = new TreeNode(1);
      root.right = new TreeNode(4);

      root.left.left = new TreeNode(5);
      root.right.left = new TreeNode(3);

      //root.left.left = new TreeNode(29);
      //root.left.right = new TreeNode(42);

      //root.right.left = new TreeNode(50);
      //root.right.right = new TreeNode(41);

      //root.right.right = new TreeNode(1);

      //var res = new Solution().RankTeams(new[] { "AXYB", "AYXB", "AXYB", "AYXB" });
      //var res2 = new Solution().MaxSubarraySumCircular(new int[] { 5,4,3,2,1 });


      //var points = new int[][]
      //{
      //  new int[]{-2, 0 },
      //  new int[]{2, 0  },
      //  new int[]{0, 2 },
      //  new int[]{0, -2 }
      //};

      var points = new int[][]
      {
        new int[]{4, 5 },
        new int[]{-4, 1 },
        new int[]{-3, 2 },
        new int[]{-4, 0 },
        new int[]{0, 2 }
      };

      /*
       [[4,5],[-4,1],[-3,2],[-4,0],[0,2]]
5
       
       */
      /*
      var res = new Solution().SmallestSufficientTeam(
        new[] { "algorithms", "math", "java", "reactjs", "csharp", "aws" },
        new List<IList<string>>
        {
          new List<string> {"algorithms","math","java"},
          new List<string> {"algorithms","math","reactjs" },
          new List<string> {"java","csharp","aws"},
          new List<string> {"reactjs","csharp" },
          new List<string> {"aws","java" },
        }
      );*/

      var res = new Solution().CountSubstrings("abe", "bbc");
    }
  }

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
 
