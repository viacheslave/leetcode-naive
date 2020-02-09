using System;
using System.Linq;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/partition-equal-subset-sum/
	///		Submission: https://leetcode.com/submissions/detail/246729567/
	/// </summary>
	internal class P0416
	{
		public bool CanPartition(int[] nums)
		{
			int sum = nums.Sum();
			if (sum % 2 == 1)
				return false;

			var expected = sum / 2;

			Array.Sort(nums);
			Array.Reverse(nums);

			return Possible(nums, 0, 0, expected);
		}

		private bool Possible(int[] nums, int index, int sum, int expected)
		{
			if (sum == expected)
				return true;

			if (sum > expected)
				return false;

			for (int i = index; i < nums.Length; i++)
			{
				if (Possible(nums, i + 1, sum + nums[i], expected))
					return true;

				while (i + 1 < nums.Length && nums[i + 1] == nums[i])
					i++;
			}

			return false;
		}
	}
}
