using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/decode-ways-ii/
	///		Submission: https://leetcode.com/submissions/detail/333881254/
	/// </summary>
	internal class P0639
	{
    public int NumDecodings(string s)
    {
      var dp = new int[s.Length + 1];
      dp[0] = 1;

      for (int i = 0; i < s.Length; i++)
      {
        var index = i + 1;
        var value = 0;

        // one left
        if (s[i] == '*')
          value = AddMod(value, dp[index - 1] * 9L);
        else if (s[i] != '0')
          value = AddMod(value, dp[index - 1]);

        dp[index] = AddMod(value, 0);

        // two left
        if (i == 0)
          continue;

        switch (s[i - 1])
        {
          case '*':
            if (s[i] == '*')
            {
              value = AddMod(value, dp[index - 2] * 15L);
            }
            else
            {
              var v = int.Parse(s[i].ToString());
              if (v > 6)
                value = AddMod(value, dp[index - 2]);
              else
                value = AddMod(value, dp[index - 2] * 2L);
            }
            break;

          case '1':
            if (s[i] == '*')
              value = AddMod(value, dp[index - 2] * 9L);
            else
              value = AddMod(value, dp[index - 2]);
            break;

          case '2':
            if (s[i] == '*')
              value = AddMod(value, dp[index - 2] * 6L);
            else
            {
              var v = int.Parse(s[i].ToString());
              if (v <= 6)
                value = AddMod(value, dp[index - 2]);
            }
            break;
        }

        dp[index] = AddMod(value, 0);
      }

      return dp[s.Length];
    }

    private int AddMod(int left, long right)
    {
      const int mod = 1_000_000_007;

      return ((left % mod) + (int)(right % mod)) % mod;
    }
  }
}
