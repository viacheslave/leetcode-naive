using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-the-smallest-divisor-given-a-threshold/
	///		Submission: https://leetcode.com/submissions/detail/289215433/
	/// </summary>
	internal class P1283
	{
		public int SmallestDivisor(int[] nums, int threshold)
		{
			var upper = 1;
			while (Calc(nums, upper) > threshold)
				upper *= 2;

			if (upper == 1)
				return 1;

			var min = upper / 2;
			var max = upper;

			while (Math.Abs(min - max) > 1)
			{
				var middle = (min + max) / 2;
				if (Calc(nums, middle) > threshold)
					min = middle;
				else
					max = middle;
			}

			if (Calc(nums, max) <= threshold)
				return max;
			return min;
		}

		public long Calc(int[] nums, int cand)
		{
			long sum = 0;
			foreach (var item in nums)
			{
				sum += (int)Math.Ceiling(1.0 * item / cand);
			}
			return sum;
		}
	}
}
