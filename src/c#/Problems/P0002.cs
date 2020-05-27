using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/two-sum/
	///		Submission: https://leetcode.com/submissions/detail/223306893/
	/// </summary>
	internal class P0002
	{
		public int[] TwoSum(int[] nums, int target)
		{
			for (int i = 0; i < nums.Length; i++)
				for (int j = i + 1; j < nums.Length; j++)
				{
					if (nums[i] + nums[j] == target)
						return new int[] { i, j };
				}

			return new int[0];
		}
	}
}
