using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/search-in-rotated-sorted-array/
	///		Submission: https://leetcode.com/submissions/detail/238522038/
	/// </summary>
	internal class P0033
	{
		public int Search(int[] nums, int target)
		{
			if (nums.Length == 0)
				return -1;

			var l = 0;
			var r = nums.Length - 1;

			while (l <= r)
			{
				int left = nums[l];
				int right = nums[r];

				if (left == target) return l;
				if (right == target) return r;

				if (r - l <= 1)
					return -1;

				var m = (r + l) / 2;
				int mid = nums[m];

				// not-rotated

				if (left <= mid && mid <= right)
				{
					if (left <= target && target <= mid)
					{
						r = m;
						continue;
					}

					if (mid <= target && target <= right)
					{
						l = m;
						continue;
					}

					return -1;
				}

				if (left <= mid)
				{
					if (left <= target && target <= mid)
					{
						r = m;
						continue;
					}

					if (mid <= target || target <= right)
					{
						l = m;
						continue;
					}

					return -1;
				}

				if (mid <= right)
				{
					if (mid <= target && target <= right)
					{
						l = m;
						continue;
					}

					if (left <= target || target <= mid)
					{
						r = m;
						continue;
					}

					return -1;
				}
			}

			return -1;
		}
	}
}
