using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/domino-and-tromino-tiling/
	///		Submission: https://leetcode.com/submissions/detail/400968207/
	/// </summary>
	internal class P0790
	{
		public int NumTilings(int N)
		{
			var dp = new Dictionary<int, int>
			{
				[0] = 1,
				[1] = 1
			};

			var mod = 1_000_000_007;

			for (var i = 2; i <= N; i++)
			{
				dp[i] = 0;

				for (var j = 1; i - j >= 0; j++)
				{
					if (j <= 2)
					{
						dp[i] += dp[i - j];
						dp[i] %= mod;
					}
					else
					{
						dp[i] += dp[i - j];
						dp[i] %= mod;

						dp[i] += dp[i - j];
						dp[i] %= mod;
					}
				}
			}

			return dp[N];
		}
	}
}
