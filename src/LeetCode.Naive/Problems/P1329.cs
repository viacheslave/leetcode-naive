using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sort-the-matrix-diagonally/
	///		Submission: https://leetcode.com/submissions/detail/297534242/
	/// </summary>
	internal class P1329
	{
		public int[][] DiagonalSort(int[][] mat)
		{
			for (var col = 0; col < mat[0].Length; col++)
				Sort(mat, (0, col));

			for (var row = 0; row < mat.Length; row++)
				Sort(mat, (row, 0));

			return mat;
		}

		private void Sort(int[][] mat, (int row, int col) point)
		{
			var originalPoint = point;

			var list = new List<int>();
			while (true)
			{
				list.Add(mat[point.row][point.col]);
				point = (point.row + 1, point.col + 1);

				if (point.row == mat.Length || point.col == mat[0].Length)
					break;
			}

			list.Sort();

			point = originalPoint;
			foreach (var item in list)
			{
				mat[point.row][point.col] = item;
				point = (point.row + 1, point.col + 1);
			}
		}
	}
}
