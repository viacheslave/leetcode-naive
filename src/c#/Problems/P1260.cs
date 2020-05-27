using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shift-2d-grid/
	///		Submission: https://leetcode.com/submissions/detail/279539368/
	/// </summary>
	internal class P1260
	{
		public IList<IList<int>> ShiftGrid(int[][] grid, int k)
		{
			var list = new List<int>();

			for (int i = 0; i < grid.Length; i++)
				for (int j = 0; j < grid[i].Length; j++)
					list.Add(grid[i][j]);

			var shifted = new List<int>();

			for (int i = 0; i < list.Count; i++)
				shifted.Add(list[(-k + i + 100 * list.Count) % list.Count]);

			var index = 0;
			var ans = new List<IList<int>>();
			for (int i = 0; i < grid.Length; i++)
			{
				var row = new List<int>();
				for (int j = 0; j < grid[i].Length; j++)
					row.Add(shifted[index++]);

				ans.Add(row);
			}

			return ans;
		}
	}
}
