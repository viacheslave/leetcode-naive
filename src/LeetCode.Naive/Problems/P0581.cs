using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shortest-unsorted-continuous-subarray/
	///		Submission: https://leetcode.com/submissions/detail/233643147/
	/// </summary>
	internal class P0581
	{
		public int FindUnsortedSubarray(int[] nums)
		{
			var copy = new int[nums.Length];
			nums.CopyTo(copy, 0);
			Array.Sort(copy);

			var start = -1;
			var end = copy.Length;

			for (var i = 0; i < copy.Length; i++)
				if (nums[i] != copy[i])
				{
					start = i;
					break;
				}

			for (var i = copy.Length - 1; i >= 0; i--)
				if (nums[i] != copy[i])
				{
					end = i;
					break;
				}

			if (end <= start)
				return 0;

			if (end == copy.Length || start == -1)
				return 0;

			return end - start + 1;
		}
	}
}
