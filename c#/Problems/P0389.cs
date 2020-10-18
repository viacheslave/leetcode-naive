using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-difference/
  ///    Submission: https://leetcode.com/submissions/detail/226138076/
  /// </summary>
  internal class P0389
  {
    public class Solution
    {
      public char FindTheDifference(string s, string t)
      {
        Dictionary<char, int> sMap = new Dictionary<char, int>();
        Dictionary<char, int> tMap = new Dictionary<char, int>();

        foreach (var ch in s)
        {
          if (!sMap.ContainsKey(ch))
            sMap[ch] = 0;

          sMap[ch]++;
        }

        foreach (var ch in t)
        {
          if (!tMap.ContainsKey(ch))
            tMap[ch] = 0;

          tMap[ch]++;
        }

        foreach (var kvp in tMap)
        {
          if (!sMap.ContainsKey(kvp.Key) || sMap[kvp.Key] != kvp.Value)
            return kvp.Key;


        }

        return ' ';
      }
    }
  }
}
