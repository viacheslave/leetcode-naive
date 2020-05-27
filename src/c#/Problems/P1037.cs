using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/valid-boomerang/
	///		Submission: https://leetcode.com/submissions/detail/230415145/
	/// </summary>
	internal class P1037
	{
		public bool IsBoomerang(int[][] points)
		{
			var s1 = GetS(points[0], points[1]);
			var s2 = GetS(points[0], points[2]);

			if (s1 == null || s2 == null)
				return false;

			return !(s1 == s2);
		}

		private double? GetS(int[] p1, int[] p2)
		{
			if (p1[0] == p2[0] && p1[1] == p2[1])
				return null;

			return 1.0 * (p2[1] - p1[1]) / (p2[0] - p1[0]);
		}
	}
}
