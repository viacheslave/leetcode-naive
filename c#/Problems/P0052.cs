using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/n-queens-ii/
	///		Submission: https://leetcode.com/submissions/detail/250202185/
	/// </summary>
	internal class P0052
	{
		public int TotalNQueens(int n)
		{
			var current = new List<(int, int)>();
			var ans = new List<List<(int, int)>>();

			Place(n, current, ans, 0);

			return ans.Count();
		}

		private void Place(int n, List<(int, int)> current, List<List<(int, int)>> ans, int row)
		{
			if (row == n)
			{
				ans.Add(current.ToList());
				return;
			}

			for (int col = 0; col < n; col++)
			{
				if (Conflicts(current, (row, col)))
					continue;

				current.Add((row, col));

				Place(n, current, ans, row + 1);

				current.RemoveAt(current.Count - 1);
			}
		}

		private bool Conflicts(List<(int row, int col)> current, (int row, int col) point)
		{
			foreach (var currentItem in current)
			{
				if (point.row == currentItem.row || point.col == currentItem.col)
					return true;

				if (Math.Abs(point.row - currentItem.row) == Math.Abs(point.col - currentItem.col))
					return true;
			}

			return false;
		}
	}
}
