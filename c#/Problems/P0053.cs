using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-subarray/
	///		Submission: https://leetcode.com/submissions/detail/233351615/
	/// </summary>
	internal class P0053
	{
		public int MaxSubArray(int[] nums)
		{
			var maxSum = nums[0];
			var currentSum = nums[0];

			for (var i = 1; i < nums.Length; i++)
			{
				currentSum = Math.Max(nums[i], currentSum + nums[i]);
				maxSum = Math.Max(maxSum, currentSum);
			}

			return maxSum;
		}
	}
}
