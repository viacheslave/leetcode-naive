using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-uncommon-subsequence-ii/
  ///    Submission: https://leetcode.com/submissions/detail/418938508/
  /// </summary>
  internal class P0522
  {
    public class Solution
    {
      public int FindLUSlength(string[] strs)
      {
        var set = strs.ToHashSet();
        var ans = -1;

        foreach (var word in set)
        {
          var count = strs.Where(s => LongestCommonSubsequence(s, word) == word.Length).Count();
          if (count == 1)
            ans = Math.Max(ans, word.Length);
        }

        return ans;
      }

      private int LongestCommonSubsequence(string text1, string text2)
      {
        var map = new Dictionary<(int, int), int>();

        return Longest(text1, text1.Length, text2, text2.Length, map);
      }

      private int Longest(string text1, int n1, string text2, int n2, Dictionary<(int, int), int> map)
      {
        if (n1 == 0 || n2 == 0)
          return 0;

        if (map.ContainsKey((n1, n2)))
          return map[(n1, n2)];

        var res = 0;

        if (text1[n1 - 1] == text2[n2 - 1])
          res = Longest(text1, n1 - 1, text2, n2 - 1, map) + 1;
        else
          res = Math.Max(Longest(text1, n1 - 1, text2, n2, map), Longest(text1, n1, text2, n2 - 1, map));

        map[(n1, n2)] = res;
        return res;
      }
    }
  }
}
