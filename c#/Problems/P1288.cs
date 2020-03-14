using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-covered-intervals/
	///		Submission: https://leetcode.com/submissions/detail/289483767/
	/// </summary>
	internal class P1288
	{
		public int RemoveCoveredIntervals(int[][] intervals)
		{
			var ans = new List<int>();

			for (var i = 0; i < intervals.Length; i++)
			{
				for (var j = 0; j < intervals.Length; j++)
				{
					if (i == j)
						continue;

					if (Covered(intervals, i, j))
					{
						ans.Add(i);
						break;
					}
				}
			}

			return intervals.Length - ans.Count;
		}

		private bool Covered(int[][] intervals, int i, int j)
		{
			var th = intervals[i];
			var other = intervals[j];

			return other[0] <= th[0] && th[1] <= other[1];
		}
	}
}
