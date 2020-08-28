using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-odd-numbers-in-an-interval-range/
	///		Submission: https://leetcode.com/submissions/detail/387692026/
	/// </summary>
	internal class P1523
	{
		public int CountOdds(int low, int high)
		{
			var lowodd = low % 2 == 1;
			var highodd = high % 2 == 1;

			if (lowodd && highodd)
				return (high - low) / 2 + 1;

			if (!lowodd && !highodd)
				return (high - low) / 2;

			return (high - low + 1) / 2;
		}
	}
}
