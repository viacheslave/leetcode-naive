using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/day-of-the-year/
	///		Submission: https://leetcode.com/submissions/detail/281318166/
	/// </summary>
	internal class P1154
	{
		public int DayOfYear(string date)
		{
			var input = DateTime.Parse(date);

			var daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			if (input.Year % 4 == 0 && input.Year % 100 != 0)
				daysInMonth[1] = 29;

			return input.Day + ((input.Month > 1) ? daysInMonth.Take(input.Month - 1).Sum() : 0);
		}
	}
}
