using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-length-of-repeated-subarray/
	///		Submission: https://leetcode.com/submissions/detail/250028236/
	/// </summary>
	internal class P0718
	{
		public int FindLength(int[] A, int[] B)
		{
			var map = new int[A.Length][];
			var max = int.MinValue;

			for (int i = 0; i < A.Length; i++)
			{
				map[i] = new int[B.Length];

				for (int j = 0; j < B.Length; j++)
				{
					if (A[i] != B[j])
					{
						map[i][j] = 0;
					}
					else
					{
						if (i == 0 || j == 0)
							map[i][j] = 1;
						else
							map[i][j] = map[i - 1][j - 1] + 1;
					}

					max = Math.Max(max, map[i][j]);
				}
			}

			//return 0;

			return max;
		}
	}
}
