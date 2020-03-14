using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/longest-increasing-subsequence/
	///		Submission: https://leetcode.com/submissions/detail/238258577/
	/// </summary>
	internal class P0300
	{
		public int LengthOfLIS(int[] nums)
		{
			if (nums.Length == 0)
				return 0;

			var longest = int.MinValue;

			for (var i = 0; i < nums.Length; i++)
			{
				longest = Math.Max(longest, Get(nums, i));
			}

			return longest;
		}

		private int Get(int[] nums, int i)
		{
			var stack = new Stack<int>();

			for (var index = i; index < nums.Length; index++)
			{
				if (stack.Count == 0)
				{
					stack.Push(nums[index]);
					continue;
				}

				if (nums[index] <= stack.Peek())
				{
					var top = stack.Pop();
					if (stack.Count > 0 && nums[index] > stack.Peek())
						stack.Push(nums[index]);
					else
						stack.Push(top);
				}
				else
				{
					stack.Push(nums[index]);
				}
			}

			return stack.Count;
		}
	}
}
