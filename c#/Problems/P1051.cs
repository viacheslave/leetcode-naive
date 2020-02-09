using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/height-checker/
	///		Submission: https://leetcode.com/submissions/detail/234781200/
	/// </summary>
	internal class P1051
	{
		public int HeightChecker(int[] heights)
		{
			var sorted = heights.ToList();
			sorted.Sort();

			var wrong = 0;
			for (var i = 0; i < heights.Length; i++)
				if (heights[i] != sorted[i])
					wrong++;

			return wrong;
		}
	}
}
