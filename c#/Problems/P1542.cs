using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-longest-awesome-substring/
  ///    Submission: https://leetcode.com/submissions/detail/425071752/
  /// </summary>
  internal class P1542
  {
    public class Solution
    {
      public int LongestAwesome(string s)
      {
        var ans = 1;
        var masks = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

        // calculate prefixes
        var pre = new int[s.Length + 1];
        for (var i = 1; i <= s.Length; i++)
          pre[i] = pre[i - 1] ^ masks[s[i - 1] - '0'];

        // calculate last indexes of prefixes
        var lastpos = new int[1024];
        for (var i = 0; i < s.Length; i++)
          lastpos[pre[i + 1]] = i;

        // check max length between last index (+ any variations(10)) and current index
        for (var i = 0; i < s.Length; i++)
        {
          ans = Math.Max(ans, lastpos[pre[i]] - i + 1);

          foreach (var mask in masks)
            ans = Math.Max(ans, lastpos[pre[i] ^ mask] - i + 1);
        }

        return ans;
      }
    }
  }
}
