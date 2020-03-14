using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-time-visiting-all-points/
	///		Submission: https://leetcode.com/submissions/detail/281349289/
	/// </summary>
	internal class P1266
	{
		public int MinTimeToVisitAllPoints(int[][] points)
		{
			var ans = 0;

			for (int index = 0; index < points.Length - 1; index++)
			{
				var s1 = (points[index][0], points[index][1]);
				var s2 = (points[index + 1][0], points[index + 1][1]);

				ans += Calc(s1, s2);
			}

			return ans;
		}

		private int Calc((int x, int y) s1, (int x, int y) s2)
		{
			if (s1.x == s2.x)
				return Math.Abs(s1.y - s2.y);

			if (s1.y == s2.y)
				return Math.Abs(s1.x - s2.x);

			var diagMove = Math.Min(Math.Abs(s1.y - s2.y), Math.Abs(s1.x - s2.x));
			var straightMove = Math.Max(Math.Abs(s1.y - s2.y), Math.Abs(s1.x - s2.x)) - diagMove;

			return diagMove + straightMove;
		}
	}
}
