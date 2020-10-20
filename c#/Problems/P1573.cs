using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-ways-to-split-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/411143704/
  /// </summary>
  internal class P1573
  {
    public class Solution
    {
      public int NumWays(string s)
      {
        var ones = s.Count(ch => ch == '1');
        if (ones % 3 != 0)
          return 0;

        var ans = 0;
        var mod = (int)1e9 + 7;

        // special case
        if (s.All(ch => ch == '0'))
          return (int)((((long)(s.Length - 1) * (long)(s.Length - 2)) / 2) % mod);

        var onesInBlock = ones / 3;

        // get indices of ones
        var onesIndices = s.Select((ch, index) => (index, ch))
          .Where(ch => ch.ch == '1')
          .Select(ch => ch.index)
          .ToList();

        // get boundaries
        var left1 = onesIndices[onesInBlock - 1];
        var left2 = onesIndices[onesInBlock];

        var right1 = onesIndices[onesIndices.Count - onesInBlock];
        var right2 = onesIndices[onesIndices.Count - onesInBlock - 1];

        ans = (int)((((long)(right1 - right2) * (long)(left2 - left1))) % mod);

        return ans;
      }
    }
  }
}
