using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/airplane-seat-assignment-probability/
	///		Submission: https://leetcode.com/submissions/detail/278499694/
	/// </summary>
	internal class P1227
	{
		public double NthPersonGetsNthSeat(int n)
		{
			return n == 1 ? 1d : 0.5;
		}
	}
}
