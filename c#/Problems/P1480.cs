using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/running-sum-of-1d-array/submissions/
	///		Submission: https://leetcode.com/submissions/detail/387707142/
	/// </summary>
	internal class P1480
	{
		public int[] RunningSum(int[] nums)
		{
			var ans = new int[nums.Length];

			var running = 0;

			for (var i = 0; i < nums.Length; i++)
			{
				running += nums[i];
				ans[i] = running;
			}

			return ans;
		}
	}
}
