using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/numbers-at-most-n-given-digit-set/
  ///    Submission: https://leetcode.com/submissions/detail/422629850/
  /// </summary>
  internal class P0902
  {
    public class Solution
    {
      public int AtMostNGivenDigitSet(string[] digits, int n)
      {
        var dp = new Dictionary<(int digit, int level), int>();
        var let = digits.Select(d => int.Parse(d)).ToList();
        var ans = 0;

        foreach (var digit in let)
          DP(dp, digit, 8, let);

        var nd = n.ToString()
          .Select(f => int.Parse(f.ToString()))
          .ToList();

        nd.Reverse();

        ans = ProcDigit(nd, nd.Count - 1, let, dp);

        for (var i = nd.Count - 1; i > 0; i--)
        {
          var nines = Enumerable.Repeat(9, i).ToList();
          ans += ProcDigit(nines, nines.Count - 1, let, dp);
        }

        return ans;
      }

      private int ProcDigit(List<int> nd, int level, List<int> let, Dictionary<(int digit, int level), int> dp)
      {
        var ans = 0;
        var digit = nd[level];

        foreach (var el in let)
        {
          if (el > digit)
            continue;

          if (level == 0)
          {
            ans++;
            continue;
          }

          if (el < digit)
          {
            foreach (var ell in let)
              ans += dp[(ell, level - 1)];
          }
          else if (el == digit)
          {
            ans += ProcDigit(nd, level - 1, let, dp);
          }
        }

        return ans;
      }

      private int DP(Dictionary<(int level, int digit), int> dp, int digit, int level, List<int> let)
      {
        if (dp.ContainsKey((digit, level)))
          return dp[(digit, level)];

        if (level == 0)
        {
          dp[(digit, 0)] = 1;
          return 1;
        }

        var ans = 0;

        foreach (var d in let)
          ans += DP(dp, d, level - 1, let);

        dp[(digit, level)] = ans;
        return ans;
      }
    }
  }
}
