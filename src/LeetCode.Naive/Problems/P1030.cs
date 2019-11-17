using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/matrix-cells-in-distance-order/
	///		Submission: https://leetcode.com/submissions/detail/237799221/
	/// </summary>
	internal class P1030
	{
		public int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
		{
			var sd = new SortedDictionary<int, List<(int, int)>>();

			for (var r = 0; r < R; r++)
			{
				for (var c = 0; c < C; c++)
				{
					var dist = Math.Abs(r - r0) + Math.Abs(c - c0);

					if (!sd.ContainsKey(dist)) sd[dist] = new List<(int, int)>();
					sd[dist].Add((r, c));
				}
			}

			return sd
					.SelectMany(_ => _.Value.Select(a => new int[] { a.Item1, a.Item2 }))
					.ToArray();
		}
	}
}
