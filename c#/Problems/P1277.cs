using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-square-submatrices-with-all-ones/
	///		Submission: https://leetcode.com/submissions/detail/283229666/
	/// </summary>
	internal class P1277
	{
		public int CountSquares(int[][] matrix)
		{
			var partRows = new List<int[]>();
			var partCols = new List<int[]>();

			var m = matrix.Length;
			var n = matrix[0].Length;

			for (int i = 0; i < m; i++)
			{
				var list = new int[n];
				for (int j = 0; j < n; j++)
				{
					list[j] = j == 0
							? matrix[i][j]
							: list[j - 1] + matrix[i][j];
				}

				partRows.Add(list);
			}

			for (int j = 0; j < n; j++)
			{
				var list = new int[m];
				for (int i = 0; i < m; i++)
				{
					list[i] = i == 0
							? matrix[i][j]
							: list[i - 1] + matrix[i][j];
				}

				partCols.Add(list);
			}

			var ans = 0;

			for (int i = 0; i < m; i++)
				for (int j = 0; j < n; j++)
					ans += GetPoint(partRows, partCols, i, j, m, n);

			return ans;
		}

		private int GetPoint(List<int[]> partRows, List<int[]> partCols, int startRow, int startCol, int rows, int cols)
		{
			var currentRow = startRow;
			var currentCol = startCol;

			var ans = 0;

			while (true)
			{
				if (currentRow >= rows || currentCol >= cols)
					break;

				var sumInRow = partRows[currentRow][currentCol] - (startCol == 0 ? 0 : partRows[currentRow][startCol - 1]);
				var sumInCol = partCols[currentCol][currentRow] - (startRow == 0 ? 0 : partCols[currentCol][startRow - 1]);

				if (sumInRow == currentRow - startRow + 1 &&
								sumInCol == currentCol - startCol + 1)
				{
					ans++;

					currentRow++;
					currentCol++;
					continue;
				}

				break;
			}

			return ans;
		}
	}
}
