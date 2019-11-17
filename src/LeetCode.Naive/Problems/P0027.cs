using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-element/
	///		Submission: https://leetcode.com/submissions/detail/226374460/
	/// </summary>
	internal class P0027
	{
		public int RemoveElement(int[] nums, int val)
		{
			var index = nums.Length - 1;

			for (var i = 0; i < nums.Length; i++)
			{
				if (val == nums[i])
				{
					index = GetSwappableIndex(nums, val);
					if (index == -1)
						return 0;

					if (index < i)
					{
						break;
					}

					var tmp = nums[index];
					nums[index] = nums[i];
					nums[i] = tmp;
				}
			}

			return index + 1;
		}

		private int GetSwappableIndex(int[] nums, int val)
		{
			for (var i = nums.Length - 1; i >= 0; i--)
			{
				if (val != nums[i])
					return i;
			}

			return -1;
		}
	}
}
