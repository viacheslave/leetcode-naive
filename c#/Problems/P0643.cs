using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-average-subarray-i/
	///		Submission: https://leetcode.com/submissions/detail/231278318/
	/// </summary>
	internal class P0643
	{
		public double FindMaxAverage(int[] nums, int k)
		{
			var max = double.MinValue;

			if (nums.Length < k)
				return 0;

			var tempSum = int.MinValue;

			for (var i = 0; i < nums.Length - k + 1; i++)
			{
				if (tempSum == int.MinValue)
				{
					var sum = 0;
					for (var j = 0; j < k; j++)
						sum += nums[i + j];

					tempSum = sum;
				}
				else
				{
					tempSum -= nums[i - 1];
					tempSum += nums[i + k - 1];
				}

				var av = 1.0 * tempSum / k;
				if (max < av)
					max = av;
			}

			return max;
		}
	}
}
