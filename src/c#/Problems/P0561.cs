using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/array-partition-i/
	///		Submission: https://leetcode.com/submissions/detail/229744140/
	/// </summary>
	internal class P0561
	{
		public int ArrayPairSum(int[] nums)
		{
			Array.Sort(nums);

			var sum = 0;
			for (var i = 0; i < nums.Length - 1; i += 2)
			{
				sum += Math.Min(nums[i], nums[i + 1]);
			}

			return sum;
		}
	}
}
