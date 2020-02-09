using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/day-of-the-week/
	///		Submission: https://leetcode.com/submissions/detail/258957424/
	/// </summary>
	internal class P1185
	{
		public string DayOfTheWeek(int day, int month, int year)
		{
			var monthmap = new Dictionary<int, int>()
			{
				[1] = 31,
				[2] = 28,
				[3] = 31,
				[4] = 30,
				[5] = 31,
				[6] = 30,
				[7] = 31,
				[8] = 31,
				[9] = 30,
				[10] = 31,
				[11] = 30,
				[12] = 31
			};

			var daymap = new Dictionary<int, string>()
			{
				[0] = "Sunday",
				[1] = "Monday",
				[2] = "Tuesday",
				[3] = "Wednesday",
				[4] = "Thursday",
				[5] = "Friday",
				[6] = "Saturday",
			};

			var days = 0;
			for (int y = 1972; y <= year; y++)
			{
				if ((y - 1) % 4 == 0)
					days += 366;
				else
					days += 365;
			}

			for (int m = 2; m <= month; m++)
			{
				if (m - 1 == 2 && year % 4 == 0 && year != 2100)
					days += 29;
				else
					days += monthmap[m - 1];
			}

			days += (day - 1);

			return daymap[(days + 5) % 7];
		}
	}
}
