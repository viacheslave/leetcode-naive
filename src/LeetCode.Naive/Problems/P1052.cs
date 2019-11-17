using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/grumpy-bookstore-owner/
	///		Submission: https://leetcode.com/submissions/detail/245759123/
	/// </summary>
	internal class P1052
	{
		public int MaxSatisfied(int[] customers, int[] grumpy, int X)
		{
			var ans = 0;
			for (int i = 0; i < X; i++)
				ans += customers[i];

			for (int i = X; i < customers.Length; i++)
				ans += grumpy[i] == 0 ? customers[i] : 0;

			int start = 0;
			var current = ans;

			while (start + X < customers.Length)
			{
				current -= grumpy[start] == 1 ? customers[start] : 0;
				current += grumpy[start + X] == 1 ? customers[start + X] : 0;

				ans = Math.Max(ans, current);

				start++;
			}

			return ans;
		}
	}
}
