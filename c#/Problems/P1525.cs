using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-good-ways-to-split-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/374537417/
  /// </summary>
  internal class P1525
  {
    public class Solution
    {
      public int NumSplits(string s)
      {
        var leftmap = new Dictionary<char, int>();
        var rightmap = new Dictionary<char, int>();

        foreach (var ch in s)
        {
          if (!rightmap.ContainsKey(ch))
            rightmap[ch] = 0;
          rightmap[ch]++;
        }

        var ans = 0;

        for (int i = 0; i < s.Length; i++)
        {
          if (leftmap.Count == rightmap.Count)
            ans++;

          var ch = s[i];

          if (!leftmap.ContainsKey(ch))
            leftmap[ch] = 0;
          leftmap[ch]++;

          rightmap[ch]--;
          if (rightmap[ch] == 0)
            rightmap.Remove(ch);
        }

        return ans;
      }
    }
  }
}
