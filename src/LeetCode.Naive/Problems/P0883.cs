using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/projection-area-of-3d-shapes/
	///		Submission: https://leetcode.com/submissions/detail/238332943/
	/// </summary>
	internal class P0883
	{
		public int ProjectionArea(int[][] grid)
		{
			return GetZ(grid) + GetX(grid) + GetY(grid);
		}

		private int GetY(int[][] grid)
		{
			var area = 0;

			for (var i = 0; i < grid.Length; i++)
			{
				var current = 0;
				for (var j = 0; j < grid.Length; j++)
					current = Math.Max(current, grid[j][i]);

				area += current;
			}

			return area;
		}

		private int GetX(int[][] grid)
		{
			var area = 0;

			for (var i = 0; i < grid.Length; i++)
			{
				var current = 0;
				for (var j = 0; j < grid.Length; j++)
					current = Math.Max(current, grid[i][j]);

				area += current;
			}

			return area;
		}

		private int GetZ(int[][] grid)
		{
			var count = 0;

			for (var i = 0; i < grid.Length; i++)
				for (var j = 0; j < grid.Length; j++)
					if (grid[i][j] > 0)
						count++;

			return count;
		}
	}
}
