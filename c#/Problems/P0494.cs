using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/target-sum/
	///		Submission: https://leetcode.com/submissions/detail/239127538/
	/// </summary>
	internal class P0494
	{
		public int FindTargetSumWays(int[] nums, int S)
		{
			return Calculate(nums, S, 0, 0);
		}

		private int Calculate(int[] nums, int target, int sum, int index)
		{
			if (index == nums.Length - 1)
			{
				var c = 0;
				if (sum + nums[index] == target)
					c++;
				if (sum - nums[index] == target)
					c++;
				return c;
			}

			return Calculate(nums, target, sum + nums[index], index + 1)
							 + Calculate(nums, target, sum - nums[index], index + 1);
		}
	}
}
