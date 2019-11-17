using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/majority-element/
	///		Submission: https://leetcode.com/submissions/detail/236805564/
	/// </summary>
	internal class P0169
	{
		public int MajorityElement(int[] nums)
		{
			if (nums.Length == 1)
				return nums[0];

			var count = 1;
			var maj = nums[0];

			for (var i = 1; i < nums.Length; i++)
			{
				if (nums[i] == maj)
				{
					count++;
				}
				else if (count == 0)
				{
					count = 1;
					maj = nums[i];
				}
				else
				{
					count--;
				}
			}

			return maj;
		}
	}
}
