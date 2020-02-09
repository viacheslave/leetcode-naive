using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/toeplitz-matrix/
	///		Submission: https://leetcode.com/submissions/detail/234742446/
	/// </summary>
	internal class P0766
	{
		public bool IsToeplitzMatrix(int[][] matrix)
		{
			var all = true;

			for (var row = 0; row < matrix.Length; row++)
				all = all && Check(matrix, row, 0);

			for (var col = 0; col < matrix[0].Length; col++)
				all = all && Check(matrix, 0, col);

			return all;
		}

		bool Check(int[][] matrix, int row, int col)
		{
			var maxrow = matrix.Length - 1;
			var maxcol = matrix[0].Length - 1;

			int value = matrix[row][col];

			while (true)
			{
				if (row <= maxrow && col <= maxcol)
				{
					var el = matrix[row][col];
					if (el != value)
						return false;

					row++;
					col++;
					continue;
				}

				break;
			}

			return true;
		}
	}
}
