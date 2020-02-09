using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-size-subarray-sum/
	///		Submission: https://leetcode.com/submissions/detail/238240323/
	/// </summary>
	internal class P0209
	{
		public int MinSubArrayLen(int s, int[] nums)
		{
			if (nums.Length == 0)
				return 0;

			var i = 0;
			var j = 0;

			var sum = nums[0];
			var minLength = int.MaxValue;

			while (i < nums.Length && j < nums.Length && i <= j)
			{
				if (sum == s)
				{
					minLength = Math.Min(j - i + 1, minLength);
					j++;

					if (j < nums.Length)
						sum += nums[j];

					continue;
				}

				if (sum < s)
				{
					j++;
					if (j < nums.Length)
						sum += nums[j];

					continue;
				}

				if (sum > s)
				{
					minLength = Math.Min(j - i + 1, minLength);

					i++;
					if (i <= j && i < nums.Length)
						sum -= nums[i - 1];

					continue;
				}
			}

			return minLength == int.MaxValue ? 0 : minLength;
		}
	}
}
