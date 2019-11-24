using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/largest-plus-sign/
	///		Submission: https://leetcode.com/submissions/detail/281346896/
	/// </summary>
	internal class P0764
	{
		public int OrderOfLargestPlusSign(int N, int[][] mines)
		{
			var ones = new int[N][];
			var minesSet = new HashSet<(int x, int y)>(mines.Select(_ => (_[0], _[1])));

			for (int row = 0; row < N; row++)
			{
				ones[row] = new int[N];
				for (int col = 0; col < N; col++)
				{
					if (minesSet.Contains((row, col)))
						ones[row][col] = 0;
				}
			}

			var rowsMap = new Dictionary<int, List<(int, int)>>();
			var colsMap = new Dictionary<int, List<(int, int)>>();

			for (int i = 0; i < N; i++)
			{
				BuildRow(N, minesSet, rowsMap, i);
				BuildCol(N, minesSet, colsMap, i);
			}

			foreach (var item in rowsMap)
			{
				var row = item.Key;

				foreach (var interval in item.Value)
				{
					for (int col = interval.Item1; col <= interval.Item2; col++)
					{
						var s1 = col - interval.Item1 + 1;
						var s2 = interval.Item2 - col + 1;

						ones[row][col] = Math.Min(s1, s2);
					}
				}
			}

			foreach (var item in colsMap)
			{
				var col = item.Key;

				foreach (var interval in item.Value)
				{
					for (int row = interval.Item1; row <= interval.Item2; row++)
					{
						ones[row][col] = Math.Min(ones[row][col], row - interval.Item1 + 1);
						ones[row][col] = Math.Min(ones[row][col], interval.Item2 - row + 1);
					}
				}
			}

			var length = 0;

			for (int row = 0; row < N; row++)
				for (int col = 0; col < N; col++)
					length = Math.Max(length, ones[row][col]);

			return length;
		}

		private void BuildCol(int N, HashSet<(int x, int y)> minesSet, Dictionary<int, List<(int, int)>> colsMap, int col)
		{
			var start = -1;
			var set = new List<(int, int)>();

			for (int row = 0; row < N; row++)
			{
				if (minesSet.Contains((row, col)))
				{
					if (start != -1)
					{
						set.Add((start, row - 1));
						start = -1;
					}
				}
				else
				{
					if (start == -1)
					{
						start = row;
					}

					if (row == N - 1)
					{
						set.Add((start, row));
					}
				}
			}

			colsMap[col] = set;
		}

		private void BuildRow(int N, HashSet<(int x, int y)> minesSet, Dictionary<int, List<(int, int)>> rowsMap, int row)
		{
			var start = -1;
			var set = new List<(int, int)>();

			for (int col = 0; col < N; col++)
			{
				if (minesSet.Contains((row, col)))
				{
					if (start != -1)
					{
						set.Add((start, col - 1));
						start = -1;
					}
				}
				else
				{
					if (start == -1)
					{
						start = col;
					}

					if (col == N - 1)
					{
						set.Add((start, col));
					}
				}
			}

			rowsMap[row] = set;
		}
	}
}
