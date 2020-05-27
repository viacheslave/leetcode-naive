using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-time-difference/
	///		Submission: https://leetcode.com/submissions/detail/239991594/
	/// </summary>
	internal class P0539
	{
		public int FindMinDifference(IList<string> timePoints)
		{
			var values = timePoints
					.Select(GetValue)
					.OrderBy(_ => _)
					.ToList();

			values.Add(values.Min() + 1440);

			for (int i = values.Count - 1; i >= 1; i--)
				values[i] -= values[i - 1];

			return values.Skip(1).Min();
		}

		private int GetValue(string s)
		{
			var parts = s.Split(':');
			return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
		}
	}
}
