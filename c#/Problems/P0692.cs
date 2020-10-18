using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/top-k-frequent-words/
  ///    Submission: https://leetcode.com/submissions/detail/231069153/
  /// </summary>
  internal class P0692
  {
    public class Solution
    {
      public IList<string> TopKFrequent(string[] words, int k)
      {
        var d = new Dictionary<string, int>();

        for (var i = 0; i < words.Length; i++)
        {
          if (!d.ContainsKey(words[i]))
            d[words[i]] = 0;

          d[words[i]]++;
        }

        return d.OrderByDescending(item => item.Value)
            .ThenBy(item => item.Key)
            .Take(k)
            .Select(item => item.Key)
            .ToList();
      }
    }
  }
}
