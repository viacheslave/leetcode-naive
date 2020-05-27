using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/min-cost-climbing-stairs/
	///		Submission: https://leetcode.com/submissions/detail/238004686/
	/// </summary>
	internal class P0746
	{
		public int MinCostClimbingStairs(int[] cost)
		{
			var dp = new int[cost.Length + 1];

			dp[0] = 0;
			dp[1] = cost[cost.Length - 1];

			for (var i = 2; i <= cost.Length; i++)
			{
				dp[i] = Math.Min(
						cost[cost.Length - i] + dp[i - 1],
						cost[cost.Length - i] + dp[i - 2]
				);
			}

			return Math.Min(dp[cost.Length - 1], dp[cost.Length]);
		}
	}
}
