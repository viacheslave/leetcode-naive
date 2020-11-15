using System;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/
  ///    Submission: https://leetcode.com/submissions/detail/420462947/
  /// </summary>
  internal class P1653
  {
    public class Solution
    {
      public int MinimumDeletions(string s)
      {
        var prb = new int[s.Length + 1];
        var sua = new int[s.Length + 1];

        for (var i = 0; i < s.Length; ++i)
        {
          prb[i + 1] = prb[i] + (s[i] == 'b' ? 1 : 0);
          sua[i + 1] = sua[i] + (s[s.Length - i - 1] == 'a' ? 1 : 0);
        }

        var ans = int.MaxValue;

        for (var i = 0; i < s.Length + 1; i++)
          ans = Math.Min(ans, prb[i] + sua[s.Length - i]);

        return ans;
      }
    }
  }
}
