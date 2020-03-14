using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/subarray-product-less-than-k/
	///		Submission: https://leetcode.com/submissions/detail/247794959/
	/// </summary>
	internal class P0713
	{
		public int NumSubarrayProductLessThanK(int[] nums, int k)
		{
			var ans = 0;

			var j = 0;

			int product = 1;

			for (int i = 0; i < nums.Length; i++)
			{
				product = product * nums[i];

				if (i == 0)
				{
					if (product < k)
						ans++;

					continue;
				}

				while (product >= k && j <= i)
				{
					product = product / nums[j];
					j++;
				}

				ans += (i - j + 1);
			}

			return ans;
		}
	}
}
