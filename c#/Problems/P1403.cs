using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-subsequence-in-non-increasing-order/
	///		Submission: https://leetcode.com/submissions/detail/324360579/
	/// </summary>
	internal class P1403
	{
		public IList<int> MinSubsequence(int[] nums)
		{
			Array.Sort(nums);

			var ans = new List<int>();
			var sum = nums.Sum();
			var currentSum = 0;
			var i = nums.Length - 1;

			while (currentSum <= sum - currentSum)
			{
				ans.Add(nums[i]);
				currentSum += nums[i];
				i--;
			}

			return ans;
		}
	}
}
