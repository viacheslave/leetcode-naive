using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/contains-duplicate-iii/
	///		Submission: https://leetcode.com/submissions/detail/246702517/
	/// </summary>
	internal class P0220
	{
		public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
		{
			if (k == 0)
				return false;

			var set = nums.Take(k + 1).ToList();
			set.Sort();

			var minDiff = long.MaxValue;
			for (int i = 1; i < set.Count; i++)
				minDiff = Math.Min(minDiff, (long)set[i] - (long)set[i - 1]);

			if (minDiff <= (long)t)
				return true;

			for (int i = 1; i < nums.Length - k; i++)
			{
				set.Remove(nums[i - 1]);

				if (nums[i + k] <= set[0])
				{
					set.Insert(0, nums[i + k]);
					minDiff = Math.Min(minDiff, (long)set[1] - (long)set[0]);
				}
				else if (nums[i + k] >= set[set.Count - 1])
				{
					set.Add(nums[i + k]);
					minDiff = Math.Min(minDiff, (long)set[set.Count - 1] - (long)set[set.Count - 2]);
				}
				else
				{
					minDiff = Insert(set, nums[i + k], 0, set.Count - 1, minDiff);
				}

				if (minDiff <= (long)t)
					return true;
			}

			return false;
		}

		private long Insert(List<int> set, int value, int left, int right, long minDiff)
		{
			if (set[left] == value)
			{
				set.Insert(left, value);
				return minDiff;
			}

			if (set[right] == value)
			{
				set.Insert(right, value);
				return minDiff;
			}

			if (right - left == 1)
			{
				set.Insert(right, value);

				minDiff = Math.Min(minDiff, (long)set[right] - (long)set[left]);
				minDiff = Math.Min(minDiff, (long)set[right + 1] - (long)set[right]);

				return minDiff;
			}

			var mid = (right + left) / 2;
			if (set[left] <= value && value <= set[mid])
				return Insert(set, value, left, mid, minDiff);
			else
				return Insert(set, value, mid, right, minDiff);
		}

		private bool Fits(List<int> set, int t)
		{
			for (int i = 1; i < set.Count; i++)
			{
				if (set[i] == set[i - 1] || set[i] - set[i - 1] <= t)
					return true;
			}

			return false;
		}
	}
}
