using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/construct-quad-tree/
	///		Submission: https://leetcode.com/submissions/detail/242576027/
	/// </summary>
	internal class P0427
	{
		public NodeQuad Construct(int[][] grid)
		{
			return Process(grid, 0, grid.Length, 0, grid.Length);
		}

		private NodeQuad Process(int[][] grid, int xstart, int xend, int ystart, int yend)
		{
			var node = new NodeQuad() { val = true };

			var sum = 0;
			for (int x = xstart; x < xend; x++)
				for (int y = ystart; y < yend; y++)
					sum += grid[x][y];

			if (sum == 0)
				return new NodeQuad() { val = false, isLeaf = true };

			if (sum == (xend - xstart) * (yend - ystart))
				return new NodeQuad() { val = true, isLeaf = true };

			node.topLeft = Process(grid,
					xstart, xstart + (xend - xstart) / 2,
					ystart, ystart + (yend - ystart) / 2);

			node.bottomLeft = Process(grid,
					xstart + (xend - xstart) / 2, xend,
					ystart, ystart + (yend - ystart) / 2);

			node.topRight = Process(grid,
					xstart, xstart + (xend - xstart) / 2,
					ystart + (yend - ystart) / 2, yend);

			node.bottomRight = Process(grid,
					xstart + (xend - xstart) / 2, xend,
					ystart + (yend - ystart) / 2, yend);

			return node;
		}
	}
}
