using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/combination-sum-iv/
	///		Submission: https://leetcode.com/submissions/detail/242216005/
	/// </summary>
	internal class P0377
	{
		public int CombinationSum4(int[] nums, int target)
		{
			Array.Sort(nums);

			var dp = new int[target + 1];
			dp[0] = 1;

			for (int t = 1; t <= target; t++)
			{
				var count = 0;

				for (int c = 0; c < nums.Length; c++)
				{
					var num = nums[c];
					if (t < num)
						break;

					count += dp[t - num];
				}

				dp[t] = count;
			}

			return dp[target];
		}
	}
}
