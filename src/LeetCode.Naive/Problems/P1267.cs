using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-servers-that-communicate/
	///		Submission: https://leetcode.com/submissions/detail/281360378/
	/// </summary>
	internal class P1267
	{
		public int CountServers(int[][] grid)
		{
			var byRow = new Dictionary<int, int>();
			var byCol = new Dictionary<int, int>();

			for (int row = 0; row < grid.Length; row++)
			{
				for (int col = 0; col < grid[row].Length; col++)
				{
					if (grid[row][col] == 1)
					{
						if (!byRow.ContainsKey(row))
							byRow[row] = 0;

						if (!byCol.ContainsKey(col))
							byCol[col] = 0;

						byRow[row]++;
						byCol[col]++;
					}
				}
			}

			var ans = 0;

			for (int row = 0; row < grid.Length; row++)
			{
				for (int col = 0; col < grid[row].Length; col++)
				{
					if (grid[row][col] == 1)
					{
						if (byRow[row] > 1 || byCol[col] > 1)
							ans++;
					}
				}
			}

			return ans;
		}
	}
}
