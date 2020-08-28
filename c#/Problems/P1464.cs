using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array/
	///		Submission: https://leetcode.com/submissions/detail/387695998/
	/// </summary>
	internal class P1464
	{
		public int MaxProduct(int[] nums)
		{
			var ans = int.MinValue;

			for (var i = 0; i < nums.Length - 1; i++)
			{
				for (var j = i + 1; j < nums.Length; j++)
				{
					ans = Math.Max(ans, (nums[i] - 1) * (nums[j] - 1));
				}
			}

			return ans;
		}
	}
}
