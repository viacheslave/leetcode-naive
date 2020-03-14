using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/
	///		Submission: https://leetcode.com/submissions/detail/303776727/
	/// </summary>
	internal class P1351
	{
		public int CountNegatives(int[][] grid)
		{
			int ans = 0;

			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[0].Length; j++)
				{
					if (grid[i][j] >= 0)
						continue;

					ans += grid[0].Length - j;
					break;
				}
			}

			return ans;
		}
	}
}
