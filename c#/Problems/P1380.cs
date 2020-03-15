using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lucky-numbers-in-a-matrix/
	///		Submission: https://leetcode.com/submissions/detail/312627338/
	/// </summary>
	internal class P1380
	{
		public IList<int> LuckyNumbers(int[][] matrix)
		{
			var mins = new int[matrix.Length];
			var maxs = new int[matrix[0].Length];

			for (var i = 0; i < matrix.Length; i++)
			{
				mins[i] = matrix[i].Min();
			}

			for (var j = 0; j < matrix[0].Length; j++)
			{
				var max = int.MinValue;
				for (var i = 0; i < matrix.Length; i++)
				{
					max = Math.Max(max, matrix[i][j]);
				}

				maxs[j] = max;
			}

			var ans = new List<int>();
			for (var i = 0; i < matrix.Length; i++)
			{
				for (var j = 0; j < matrix[0].Length; j++)
				{
					if (matrix[i][j] == mins[i] && matrix[i][j] == maxs[j])
						ans.Add(matrix[i][j]);
				}
			}

			return ans;
		}
	}
}
