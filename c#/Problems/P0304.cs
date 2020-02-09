using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/range-sum-query-2d-immutable/
	///		Submission: https://leetcode.com/submissions/detail/247866032/
	/// </summary>
	internal class P0304
	{
		public class NumMatrix
		{
			int[][] _sums;

			public NumMatrix(int[][] matrix)
			{
				_sums = new int[matrix.Length][];

				for (int i = 0; i < matrix.Length; i++)
				{
					_sums[i] = new int[matrix[i].Length];
					for (int j = 0; j < matrix[i].Length; j++)
						_sums[i][j] = (j == 0) ? matrix[i][j] : (_sums[i][j - 1] + matrix[i][j]);
				}
			}

			public int SumRegion(int row1, int col1, int row2, int col2)
			{
				var ans = 0;

				for (int r = row1; r <= row2; r++)
				{
					ans += _sums[r][col2] - ((col1 == 0) ? 0 : _sums[r][col1 - 1]);
				}

				return ans;
			}
		}

		/**
		 * Your NumMatrix object will be instantiated and called as such:
		 * NumMatrix obj = new NumMatrix(matrix);
		 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
		 */
	}
}
