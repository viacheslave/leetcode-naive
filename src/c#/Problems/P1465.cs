using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts/
	///		Submission: https://leetcode.com/submissions/detail/349785919/
	/// </summary>
	internal class P1465
	{
		public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
		{
			var yarr = new List<int>(horizontalCuts);
			yarr.Add(0);
			yarr.Add(h);

			var xarr = new List<int>(verticalCuts);
			xarr.Add(0);
			xarr.Add(w);

			yarr.Sort();
			xarr.Sort();

			var maxdiff_y = int.MinValue;
			for (int i = 1; i < yarr.Count; i++)
				maxdiff_y = Math.Max(yarr[i] - yarr[i - 1], maxdiff_y);

			var maxdiff_x = int.MinValue;
			for (int i = 1; i < xarr.Count; i++)
				maxdiff_x = Math.Max(xarr[i] - xarr[i - 1], maxdiff_x);

			return (int)(((long)maxdiff_x * (long)maxdiff_y) % 1_000_000_007);
		}
	}
}
