using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///		Problem: https://leetcode.com/problems/knight-dialer/
  ///		Submission: https://leetcode.com/submissions/detail/395107269/
  /// </summary>
  internal class P0935
	{
		public int KnightDialer(int n)
    {
        var mod = 1_000_000_007;

        var map = new Dictionary<int, List<int>>
        {
            [0] = new List<int> { 4, 6 },
            [1] = new List<int> { 6, 8 },
            [2] = new List<int> { 7, 9 },
            [3] = new List<int> { 4, 8 },
            [4] = new List<int> { 0, 3, 9 },
            [5] = new List<int> { },
            [6] = new List<int> { 0, 1, 7 },
            [7] = new List<int> { 2, 6 },
            [8] = new List<int> { 1, 3 },
            [9] = new List<int> { 2, 4 },
        };

        var dp = new int[n][];

        for (var i = 0; i <= n- 1; i++)
            dp[i] = new int[10];

        for (var j = 0; j <= 9; j++)
            dp[0][j] = 1;

        for (var i = 1; i <= n - 1; i++)
        {
            for (var j = 0; j <= 9; j++)
            {
                var values = map[j];

                for (var k = 0; k < values.Count; k++)
                {
                    dp[i][values[k]] += dp[i - 1][j];
                    dp[i][values[k]] %= mod;
                }
            }
        }

        var ans = 0;

        for (var i = 0; i < dp[n - 1].Length; i++)
        {
            ans += dp[n - 1][i];
            ans %= mod;
        }

        return ans;
    }
	}
}
