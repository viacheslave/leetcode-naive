using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/search-insert-position/
	///		Submission: https://leetcode.com/submissions/detail/226678607/
	/// </summary>
	internal class P0035
	{
		public int SearchInsert(int[] nums, int target)
		{
			for (var i = 0; i < nums.Length; i++)
			{
				if (target == nums[i])
					return i;

				if (target > nums[i])
					continue;

				return i;
			}
			return nums.Length;
		}
	}
}
