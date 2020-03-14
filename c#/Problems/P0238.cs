using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/product-of-array-except-self/
	///		Submission: https://leetcode.com/submissions/detail/234962003/
	/// </summary>
	internal class P0238
	{
		public int[] ProductExceptSelf(int[] nums)
		{
			var res = new int[nums.Length];

			var inc = new int[nums.Length];
			inc[0] = nums[0];

			for (var i = 1; i < nums.Length; i++)
				inc[i] = inc[i - 1] * nums[i];

			var prod = 1;
			for (var i = nums.Length - 1; i >= 0; i--)
			{
				var cc = 1;
				if (i - 1 >= 0)
					cc = inc[i - 1];

				res[i] = cc * prod;
				prod *= nums[i];
			}

			return res;
		}
	}
}
