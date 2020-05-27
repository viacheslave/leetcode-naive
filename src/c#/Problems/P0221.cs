using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximal-square/
	///		Submission: https://leetcode.com/submissions/detail/242582125/
	/// </summary>
	internal class P0221
	{
		public int MaximalSquare(char[][] matrix)
		{
			if (matrix.Length == 0)
				return 0;

			var max = 0;

			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					if (matrix[i][j] == '1')
					{
						max = Math.Max(max, 1);

						if (
								Valid(matrix, i + 1, j) && matrix[i + 1][j] == '1' &&
								Valid(matrix, i, j + 1) && matrix[i][j + 1] == '1')
						{
							for (int ii = i + max, jj = j + max; ; ii++, jj++)
							{
								if (!Valid(matrix, ii, jj))
									break;

								if (AllOnes(matrix, i, j, ii, jj))
									max = Math.Max(max, (ii - i + 1));
							}
						}
					}
				}
			}

			return max * max;
		}

		private bool AllOnes(char[][] matrix, int xstart, int ystart, int xend, int yend)
		{
			for (int i = xstart; i <= xend; i++)
				for (int j = ystart; j <= yend; j++)
					if (matrix[i][j] == '0')
						return false;

			return true;
		}

		private bool Valid(char[][] matrix, int i, int j)
		{
			return i >= 0 && j >= 0 && i < matrix.Length && j < matrix[0].Length;
		}
	}
}
