using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/play-with-chips/
	///		Submission: https://leetcode.com/submissions/detail/278799301/
	/// </summary>
	internal class P1217
	{
		public int MinCostToMoveChips(int[] chips)
		{
			var oddSum = chips.Count(c => c % 2 == 1);
			var evenSum = chips.Count(c => c % 2 == 0);

			if (oddSum == 0 || evenSum == 0)
				return 0;

			return Math.Min(evenSum, oddSum);
		}
	}
}
