using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/can-i-win/
  ///    Submission: https://leetcode.com/submissions/detail/428293580/
  /// </summary>
  internal class P0464
  {
    public class Solution
    {
      public bool CanIWin(int maxChoosableInteger, int desiredTotal)
      {
        // you can never place last number
        if (maxChoosableInteger * (maxChoosableInteger + 1) / 2 < desiredTotal)
          return false;

        var dp = new Dictionary<(int points, int mask), bool>();
        var ans = Possible(dp, (0, 0), maxChoosableInteger, desiredTotal);

        return ans;
      }

      private bool Possible(
        Dictionary<(int points, int mask), bool> dp,
        (int points, int mask) p, int maxChoosableInteger, int desiredTotal)
      {
        if (dp.ContainsKey(p))
          return dp[p];

        var can = false;
        var mask = p.mask;

        for (var choice = maxChoosableInteger; choice > 0; choice--)
        {
          if (can)
            break;

          if (mask % 2 == 0)
          {
            var points = p.points + choice;
            if (points >= desiredTotal)
            {
              can = true;
              break;
            }

            var masknext = p.mask | (1 << (maxChoosableInteger - choice));

            // you win if opponent is guaranteed to loose at least once
            can |= !Possible(dp, (points, masknext), maxChoosableInteger, desiredTotal);
          }

          mask >>= 1;
        }

        dp[p] = can;
        return can;
      }
    }
  }
}
