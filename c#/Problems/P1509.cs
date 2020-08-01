using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/
	///		Submission: https://leetcode.com/submissions/detail/374450518/
	/// </summary>
	internal class P1509
	{
		public int MinDifference(int[] nums)
		{
			if (nums.Length <= 4)
				return 0;

			Array.Sort(nums);

			var ans = int.MaxValue;

			for (var i = 0; i <= 3; i++)
			{
				var diff = Math.Abs(nums[nums.Length - 1 - 3 + i] - nums[i]);
				ans = Math.Min(ans, diff);
			}

			return ans;
		}
	}
}
