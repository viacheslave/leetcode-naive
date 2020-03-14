using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reshape-the-matrix/
	///		Submission: https://leetcode.com/submissions/detail/229587466/
	/// </summary>
	internal class P0566
	{
		public int[][] MatrixReshape(int[][] nums, int r, int c)
		{
			if (nums.Length == 0)
				return nums;

			var s = nums[0].Length * nums.Length;
			if (s != r * c)
				return nums;


			int row = 0;
			int col = 0;

			int[][] res = new int[r][];

			for (var nr = 0; nr < nums.Length; nr++)
			{
				for (var nc = 0; nc < nums[nr].Length; nc++)
				{
					if (col == 0)
						res[row] = new int[c];

					res[row][col] = nums[nr][nc];
					col++;

					if (col == c)
					{
						col = 0;
						row++;
					}
				}
			}

			return res;
		}
	}
}
