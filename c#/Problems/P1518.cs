using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/water-bottles/
	///		Submission: https://leetcode.com/submissions/detail/387690183/
	/// </summary>
	internal class P1518
	{
		public int NumWaterBottles(int numBottles, int numExchange)
		{
			var ans = 0;

			while (numBottles >= numExchange)
			{
				ans += numExchange;
				numBottles -= numExchange;
				numBottles++;
			}

			return ans + numBottles;
		}
	}
}
