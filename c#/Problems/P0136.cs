using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/single-number/
	///		Submission: https://leetcode.com/submissions/detail/226732901/
	/// </summary>
	internal class P0136
	{
		public int SingleNumber(int[] nums)
		{
			HashSet<int> h = new HashSet<int>();

			for (var i = 0; i < nums.Length; i++)
				if (!h.Contains(nums[i]))
					h.Add(nums[i]);
				else
					h.Remove(nums[i]);

			foreach (var item in h)
				return item;

			return 0;
		}
	}
}
