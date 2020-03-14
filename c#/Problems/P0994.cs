using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rotting-oranges/
	///		Submission: https://leetcode.com/submissions/detail/234285384/
	/// </summary>
	internal class P0994
	{
		public int OrangesRotting(int[][] grid)
		{
			var value = Rotten(grid, 0);

			for (var i = 0; i < grid.Length; i++)
				for (var j = 0; j < grid[i].Length; j++)
					if (grid[i][j] == 1)
						return -1;

			return value;
		}

		private int Rotten(int[][] grid, int currentMin)
		{
			var fresh = 0;

			var rotten = new List<(int, int)>();
			for (var i = 0; i < grid.Length; i++)
				for (var j = 0; j < grid[i].Length; j++)
					if (grid[i][j] == 2)
						rotten.Add((i, j));

			foreach (var (i, j) in rotten)
			{
				if (IsValid(grid, i, j - 1) && grid[i][j - 1] == 1)
				{
					fresh++;
					grid[i][j - 1] = 2;
				}

				if (IsValid(grid, i, j + 1) && grid[i][j + 1] == 1)
				{
					fresh++;
					grid[i][j + 1] = 2;
				}

				if (IsValid(grid, i - 1, j) && grid[i - 1][j] == 1)
				{
					fresh++;
					grid[i - 1][j] = 2;
				}

				if (IsValid(grid, i + 1, j) && grid[i + 1][j] == 1)
				{
					fresh++;
					grid[i + 1][j] = 2;
				}
			}

			if (fresh == 0)
				return currentMin;

			return Rotten(grid, currentMin + 1);
		}

		private bool IsValid(int[][] grid, int row, int col)
		{
			return row >= 0
							&& row < grid.Length
							&& col >= 0
							&& col < grid[0].Length;
		}
	}
}
