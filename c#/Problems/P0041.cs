using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/first-missing-positive/
	///		Submission: https://leetcode.com/submissions/detail/402610646/
	/// </summary>
	internal class P0041
	{
		public int FirstMissingPositive(int[] nums)
		{
			if (nums.Length == 0)
				return 1;

			for (var i = 0; i < nums.Length; ++i)
			{
				TraverseFrom(nums, nums[i]);
			}

			for (var i = 0; i < nums.Length; ++i)
			{
				if (nums[i] != i + 1)
					return i + 1;
			}

			return nums.Length + 1;
		}

		private void TraverseFrom(int[] nums, int start)
		{
			var storage = start;

			while (storage - 1 < nums.Length && storage - 1 >= 0 && nums[storage - 1] != storage)
			{
				if (nums[storage - 1] <= 0 || nums[storage - 1] > nums.Length + 1)
				{
					nums[storage - 1] = storage;
					break;
				}

				var index = storage - 1;

				storage = nums[index];
				nums[index] = index + 1;
			}
		}
	}
}
