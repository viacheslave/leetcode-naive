using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/decrease-elements-to-make-array-zigzag/
	///		Submission: https://leetcode.com/submissions/detail/391013462/
	/// </summary>
	internal class P1144
	{
		public int MovesToMakeZigzag(int[] nums)
		{
			if (nums.Length <= 1)
				return 0;

			var gt = Math.Min(Moves(nums, 0, 1), Moves(nums, 1, 1));
			var lt = Math.Min(Moves(nums, 0, -1), Moves(nums, 1, -1));

			return Math.Min(gt, lt);
		}

		private int Moves(int[] nums, int inc, int mode)
		{
			var arr = new int[nums.Length];
			Array.Copy(nums, arr, nums.Length);

			var ans = 0;

			for (var i = inc; i < arr.Length; i += 2)
			{
				var left = i - 1;
				var right = i + 1;

				if (left < 0)
				{
					if (arr[i] >= arr[right])
						ans += Math.Abs(arr[i] - arr[right]) + 1;
					continue;
				}

				if (right >= arr.Length)
				{
					if (arr[i] >= arr[left])
						ans += Math.Abs(arr[i] - arr[left]) + 1;
					continue;
				}

				if (mode == -1 && arr[i] < arr[left] && arr[i] < arr[right])
					continue;

				ans += Math.Abs(arr[i] - Math.Min(arr[right], arr[left])) + 1;
			}

			return ans;
		}
	}
}
