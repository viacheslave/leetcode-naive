using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/champagne-tower/
	///		Submission: https://leetcode.com/submissions/detail/281117306/
	/// </summary>
	internal class P0799
	{
		public double ChampagneTower(int poured, int query_row, int query_glass)
		{
			var rows = new List<double[]>();
			for (int i = 1; i <= 101; i++)
				rows.Add(new double[i]);

			rows[0][0] = poured;

			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < rows[i].Length; j++)
				{
					if (rows[i][j] > 1)
					{
						rows[i + 1][j] += (rows[i][j] - 1) / 2d;
						rows[i + 1][j + 1] += (rows[i][j] - 1) / 2d;
						rows[i][j] = 1;
					}
				}
			}

			return rows[query_row][query_glass];
		}
	}
}
