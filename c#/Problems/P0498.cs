using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/diagonal-traverse/
	///		Submission: https://leetcode.com/submissions/detail/234925827/
	/// </summary>
	internal class P0498
	{
		public int[] FindDiagonalOrder(int[][] matrix)
		{
			if (matrix.Length == 0)
				return Array.Empty<int>();

			var list = new List<int>();

			var top = true;

			for (var j = 0; j < matrix[0].Length; j++)
			{
				var arr = GetDiagonal(matrix, 0, j);
				if (top) arr.Reverse();

				list.AddRange(arr);

				top = !top;
			}

			for (var i = 1; i < matrix.Length; i++)
			{
				var arr = GetDiagonal(matrix, i, matrix[0].Length - 1);
				if (top) arr.Reverse();

				list.AddRange(arr);

				top = !top;
			}

			return list.ToArray();
		}

		List<int> GetDiagonal(int[][] matrix, int row, int col)
		{
			var list = new List<int>();

			while (IsValid(matrix, row, col))
			{
				list.Add(matrix[row][col]);
				row++;
				col--;
			}

			return list;
		}

		bool IsValid(int[][] matrix, int row, int col)
		{
			return row >= 0
					&& col >= 0
					&& row < matrix.Length
					&& col < matrix[0].Length;
		}
	}
}
