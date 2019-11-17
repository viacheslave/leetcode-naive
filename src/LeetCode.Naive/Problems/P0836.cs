using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rectangle-overlap/
	///		Submission: https://leetcode.com/submissions/detail/244161912/
	/// </summary>
	internal class P0836
	{
		public bool IsRectangleOverlap(int[] rec1, int[] rec2)
		{
			var r1_1 = (x: rec1[0], y: rec1[1]);
			var r1_2 = (x: rec1[2], y: rec1[3]);

			var r2_1 = (x: rec2[0], y: rec2[1]);
			var r2_2 = (x: rec2[2], y: rec2[3]);

			return
					Math.Max(r1_1.x, r2_1.x) < Math.Min(r1_2.x, r2_2.x) &&
					Math.Max(r1_1.y, r2_1.y) < Math.Min(r1_2.y, r2_2.y);
		}
	}
}
