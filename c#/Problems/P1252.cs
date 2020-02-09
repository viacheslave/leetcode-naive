using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/cells-with-odd-values-in-a-matrix/
	///		Submission: https://leetcode.com/submissions/detail/278190668/
	/// </summary>
	internal class P1252
	{
		public int OddCells(int n, int m, int[][] indices)
		{
			var matrix = new int[n][];

			for (int i = 0; i < n; i++)
				matrix[i] = new int[m];

			for (int i = 0; i < indices.Length; i++)
			{
				var pair = indices[i];
				var row = pair[0];
				var col = pair[1];

				for (int c = 0; c < m; c++)
					matrix[row][c]++;

				for (int r = 0; r < n; r++)
					matrix[r][col]++;
			}

			var ans = 0;
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (matrix[i][j] % 2 == 1)
						ans++;

			return ans;
		}
	}
}
