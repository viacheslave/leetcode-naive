using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/stone-game-iv/
	///		Submission: https://leetcode.com/submissions/detail/405805808/
	/// </summary>
	internal class P1510
	{
		public bool WinnerSquareGame(int n)
		{
			var dp = new bool[n + 1];
			dp[1] = true;

			for (var i = 1; i <= n; ++i)
			{
				for (int j = 1; j * j <= i; ++j)
				{
					dp[i] = dp[i] | (!dp[i - j * j]);
				}
			}

			return dp[n];
		}
	}
}
