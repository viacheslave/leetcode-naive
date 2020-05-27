using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/transpose-matrix/
	///		Submission: https://leetcode.com/submissions/detail/227864486/
	/// </summary>
	internal class P0867
	{
		public int[][] Transpose(int[][] A)
		{
			if (A.Length == 0)
				return A;

			var w = A.Length;
			var h = A[0].Length;

			//return new int[][] {new int[] {w,h}};

			var res = new int[h][];

			for (var i = 0; i < h; i++)
			{
				var arr = new int[w];

				for (var j = 0; j < w; j++)
				{
					arr[j] = A[j][i];
				}

				res[i] = arr;
			}

			return res;
		}
	}
}
