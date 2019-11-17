using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/max-consecutive-ones/
	///		Submission: https://leetcode.com/submissions/detail/227164972/
	/// </summary>
	internal class P0485
	{
		public int FindMaxConsecutiveOnes(int[] nums)
		{
			var zeroIndex = -1;
			var max = 0;

			for (var i = 0; i < nums.Length; i++)
			{
				if (nums[i] == 0)
				{
					var length = i - zeroIndex - 1;
					if (length > max)
						max = length;

					zeroIndex = i;
				}

				if (nums[i] == 1 && i == nums.Length - 1)
				{
					var length1 = i - zeroIndex;
					if (length1 > max)
						max = length1;
				}
			}

			return max;
		}
	}
}
