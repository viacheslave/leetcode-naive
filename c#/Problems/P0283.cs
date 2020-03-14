using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/move-zeroes
	///		Submission: https://leetcode.com/submissions/detail/227858945/
	/// </summary>
	internal class P0283
	{
		public void MoveZeroes(int[] nums)
		{
			if (nums.Length <= 1)
				return;

			for (var index = nums.Length - 1; index >= 0; index--)
			{
				if (nums[index] == 0)
					Move(nums, index);
			}
		}

		private void Move(int[] nums, int index)
		{
			for (var i = index; i < nums.Length - 1; i++)
			{
				if (nums[i + 1] == 0)
					continue;

				var tmp = nums[i + 1];
				nums[i + 1] = nums[i];
				nums[i] = tmp;
			}
		}
	}
}
