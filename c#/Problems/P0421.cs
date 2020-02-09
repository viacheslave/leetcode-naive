using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/
	///		Submission: https://leetcode.com/submissions/detail/243242699/
	/// </summary>
	internal class P0421
	{
		public int FindMaximumXOR(int[] nums)
		{
			if (nums.Length < 2)
				return 0;

			var max = int.MinValue;

			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					max = Math.Max(max, nums[i] ^ nums[j]);
				}
			}

			return max;
		}
	}
}
