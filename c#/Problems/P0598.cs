using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/range-addition-ii/
	///		Submission: https://leetcode.com/submissions/detail/231081468/
	/// </summary>
	internal class P0598
	{
		public int MaxCount(int m, int n, int[][] ops)
		{
			var minX = m;
			var minY = n;

			var count = 0;

			foreach (var op in ops)
			{
				if (op[0] < minX) minX = op[0];
				if (op[1] < minY) minY = op[1];

				count++;
			}

			return minX * minY;
		}
	}
}
