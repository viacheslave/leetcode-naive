using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-product-of-three-numbers/
	///		Submission: https://leetcode.com/submissions/detail/234064233/
	/// </summary>
	internal class P0628
	{
		public int MaximumProduct(int[] nums)
		{
			Array.Sort(nums);

			var left = 0;
			if (nums[0] < 0 && nums[1] < 0)
				left = nums[0] * nums[1];

			var supposed = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
			var supposedLeft = nums[nums.Length - 1] * left;

			return Math.Max(supposed, supposedLeft);
		}
	}
}
