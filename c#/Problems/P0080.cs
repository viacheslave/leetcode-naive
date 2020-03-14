using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
	///		Submission: https://leetcode.com/submissions/detail/241783286/
	/// </summary>
	internal class P0080
	{
		public int RemoveDuplicates(int[] nums)
		{
			if (nums.Length == 0) return 0;
			if (nums.Length == 1) return 1;

			var start = 0;
			var end = 0;

			var count = nums.Length;

			for (int i = 1; i < count; i++)
			{
				if (i >= count)
					break;

				var cur = nums[i];
				var prev = nums[i - 1];

				if (cur == prev)
				{
					end = i;
					continue;
				}

				var length = end - start + 1;
				if (length <= 2)
				{
					start = i;
					end = i;
					continue;
				}

				var shiftLeft = start + 2;
				var steps = end - shiftLeft + 1;

				for (int j = shiftLeft; j < nums.Length - steps; j++)
					nums[j] = nums[j + steps];

				count -= end - (start + 1);

				start += 2;
				end = start;
				i = start;
			}

			// final
			if (end - start + 1 > 2)
				count -= end - (start + 1);

			return count;
		}
	}
}
