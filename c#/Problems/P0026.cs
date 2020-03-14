using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-duplicates-from-sorted-array/
	///		Submission: https://leetcode.com/submissions/detail/229710471/
	/// </summary>
	internal class P0026
	{
		public int RemoveDuplicates(int[] nums)
		{
			if (nums.Length == 0)
				return 0;

			if (nums.Length == 1)
				return 1;

			var seqStart = 0;
			var current = seqStart + 1;

			var shifted = 0;

			while (current < nums.Length)
			{
				if (nums[current] == nums[seqStart])
				{
					current++;
					continue;
				}

				if (current - seqStart == 1)
				{
					seqStart++;
					continue;
				}

				ShiftLeft(nums, current, current - seqStart - 1);

				//shifted = shifted + current - seqStart - 1;

				seqStart++;
				current = seqStart + 1;
			}

			var index = 0;
			while (index + 1 < nums.Length && nums[index] < nums[index + 1])
			{
				index++;
			}

			return index + 1;
		}

		private void ShiftLeft(int[] nums, int current, int stepsLeft)
		{
			while (current < nums.Length)
			{
				nums[current - stepsLeft] = nums[current];
				current++;
			}
		}
	}
}
