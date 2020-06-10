using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/house-robber/
	///		Submission: https://leetcode.com/submissions/detail/241999674/
	/// </summary>
	internal class P0198
	{
		public int Rob(int[] nums)
		{
			var max = 0;

			var dp = new Dictionary<int, int>();
			dp[-1] = 0;
			dp[-2] = 0;
			dp[-3] = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				dp[i] = nums[i] + Math.Max(dp[i - 2], dp[i - 3]);
				max = Math.Max(max, dp[i]);
			}

			return max;
		}
	}
}
