using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/next-greater-element-ii/
	///		Submission: https://leetcode.com/submissions/detail/237113586/
	/// </summary>
	internal class P0503
	{
		public int[] NextGreaterElements(int[] nums)
		{
			if (nums.Length == 0)
				return new int[0];

			if (nums.Length == 1)
				return new int[] { -1 };

			var anchorEl = nums[0];
			var nextGreaterIndex = -1;

			var res = new int[nums.Length];

			for (var i = 0; i < nums.Length; i++)
			{
				/*
				if (nextGreaterIndex != -1)
				{
						if (nums[i] < anchorEl)
						{
								res[i] = nums[nextGreaterIndex];
								continue;
						}
						else
						{
								nextGreaterIndex = -1;
						}
				}*/

				res[i] = -1;
				for (var j = 1; j < nums.Length; j++)
				{
					var index = (i + j >= nums.Length) ? (i + j - nums.Length) : i + j;
					if (nums[index] > nums[i])
					{
						nextGreaterIndex = index;
						anchorEl = nums[i];

						res[i] = nums[index];
						break;
					}
				}
			}

			return res;
		}
	}
}
