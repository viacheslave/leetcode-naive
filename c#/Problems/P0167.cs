using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
	///		Submission: https://leetcode.com/submissions/detail/239324082/
	/// </summary>
	internal class P0167
	{
		public int[] TwoSum(int[] numbers, int target)
		{
			var i = 0;
			var j = numbers.Length - 1;

			while (i < j)
			{
				if (numbers[i] + numbers[j] == target)
					return new int[] { i + 1, j + 1 };

				if (numbers[i] + numbers[j] < target)
				{
					i++; continue;
				}

				if (numbers[i] + numbers[j] > target)
				{
					j--; continue;
				}
			}

			return null;
		}
	}
}
