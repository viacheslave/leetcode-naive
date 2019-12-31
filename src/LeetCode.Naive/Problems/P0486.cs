﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/predict-the-winner/
	///		Submission: https://leetcode.com/submissions/detail/290045174/
	/// </summary>
	internal class P0486
	{
		public bool PredictTheWinner(int[] nums)
		{
			if (nums.Length == 1 && nums[0] == 0)
				return true;

			var mem = new Dictionary<(int, int), int>();
			var res = Get(nums, 0, nums.Length - 1, mem);

			var other = nums.Sum() - res;
			return res >= other;
		}

		private int Get(int[] piles, int left, int right, Dictionary<(int, int), int> mem)
		{
			if (left == right)
				return piles[left];

			if (right - left == 1)
				return Math.Max(piles[left], piles[right]);

			if (mem.ContainsKey((left, right)))
				return mem[(left, right)];

			var leftcase = piles[left] + Math.Min(
					Get(piles, left + 1, right - 1, mem),
					Get(piles, left + 2, right, mem));

			var rightcase = piles[right] + Math.Min(
					Get(piles, left, right - 2, mem),
					Get(piles, left + 1, right - 1, mem));

			mem[(left, right)] = Math.Max(leftcase, rightcase);
			return mem[(left, right)];
		}
	}
}
