using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/bulb-switcher-ii/
	///		Submission: https://leetcode.com/submissions/detail/240300688/
	/// </summary>
	internal class P0672
	{
		public int FlipLights(int n, int m)
		{
			if (m == 0)
				return 1;

			if (n == 1)
				return 2;

			if (n == 2)
			{
				if (m == 1) return 3;
				else return 4;
			}

			if (m == 1) return 4;
			if (m == 2) return 7;
			return 8;
		}
	}
}
