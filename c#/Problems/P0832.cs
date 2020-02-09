using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/flipping-an-image/
	///		Submission: https://leetcode.com/submissions/detail/230680661/
	/// </summary>
	internal class P0832
	{
		public int[][] FlipAndInvertImage(int[][] A)
		{
			var rows = A.Length;
			var cols = A[0].Length;

			var mod = new int[rows][];

			for (var i = 0; i < rows; i++)
			{
				if (mod[i] == null)
					mod[i] = new int[cols];

				for (var j = 0; j < cols; j++)
					mod[i][j] = 1 - A[i][cols - 1 - j];
			}

			return mod;
		}
	}
}
