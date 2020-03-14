using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-falling-path-sum/
	///		Submission: https://leetcode.com/submissions/detail/240295287/
	/// </summary>
	internal class P0931
	{
		public int MinFallingPathSum(int[][] A)
		{
			var dp = new int[A.Length][];

			for (int i = A.Length - 1; i >= 0; i--)
			{
				dp[i] = new int[A[0].Length];

				for (int j = 0; j < A[0].Length; j++)
				{
					if (i == A.Length - 1)
					{
						dp[i][j] = A[i][j];
						continue;
					}

					var min = A[i][j] + dp[i + 1][j];
					if (j - 1 >= 0)
						min = Math.Min(min, A[i][j] + dp[i + 1][j - 1]);
					if (j + 1 < A[0].Length)
						min = Math.Min(min, A[i][j] + dp[i + 1][j + 1]);

					dp[i][j] = min;
				}
			}

			return dp[0].Min();
		}
	}
}
