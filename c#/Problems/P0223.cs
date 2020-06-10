using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rectangle-area/
	///		Submission: https://leetcode.com/submissions/detail/250043730/
	/// </summary>
	internal class P0223
	{
		public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
		{
			var r1 = Math.Abs(((long)C - (long)A)) * Math.Abs(((long)D - (long)B));
			var r2 = Math.Abs(((long)G - (long)E)) * Math.Abs(((long)H - (long)F));

			var ix = ((long)Math.Min(C, G) - (long)Math.Max(A, E));
			var iy = ((long)Math.Min(D, H) - (long)Math.Max(B, F));

			if (ix >= 0 && iy >= 0)
				return (int)(r1 + r2 - Math.Abs(ix * iy));

			return (int)(r1 + r2);
		}
	}
}
