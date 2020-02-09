using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/construct-the-rectangle/
	///		Submission: https://leetcode.com/submissions/detail/230837646/
	/// </summary>
	internal class P0492
	{
		public int[] ConstructRectangle(int area)
		{
			int l = 0, w = 0;

			for (var i = 1; i <= Math.Sqrt(area); i++)
			{
				if (area % i == 0)
				{
					l = i;
					w = area / i;
				}
			}

			return new int[2] { w, l };
		}
	}
}
