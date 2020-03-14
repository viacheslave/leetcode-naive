using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/pyramid-transition-matrix/
	///		Submission: https://leetcode.com/submissions/detail/240274213/
	/// </summary>
	internal class P0756
	{
		bool found = false;

		public bool PyramidTransition(string bottom, IList<string> allowed)
		{
			var map = allowed.GroupBy(item => item.Substring(0, 2)).ToDictionary(_ => _.Key, _ => _.ToList());

			var matrix = new char[bottom.Length][];

			for (int i = 1; i < bottom.Length; i++)
				matrix[i] = new char[bottom.Length - i];

			matrix[0] = bottom.ToCharArray();

			Pick(map, matrix, row: 0, col: 0);

			return found;
		}

		private void Pick(Dictionary<string, List<string>> map, char[][] matrix, int row, int col)
		{
			if (col == matrix[row].Length - 1)
			{
				row = row + 1;
				col = 0;

				if (row == matrix.Length - 1)
				{
					found = true;
					return;
				}
			}

			if (found) return;

			map.TryGetValue(new string(new[] { matrix[row][col], matrix[row][col + 1] }), out var variants);
			if (variants == null)
				return;

			foreach (var variant in variants)
			{
				matrix[row + 1][col] = variant[2];
				Pick(map, matrix, row, col + 1);
			}
		}
	}
}
