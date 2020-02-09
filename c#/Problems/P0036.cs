using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/valid-sudoku/
	///		Submission: https://leetcode.com/submissions/detail/232034937/
	/// </summary>
	internal class P0036
	{
		public bool IsValidSudoku(char[][] board)
		{
			for (var i = 0; i < 9; i++)
				if (!IsValidRow(board, i))
					return false;

			for (var i = 0; i < 9; i++)
				if (!IsValidCol(board, i))
					return false;

			return IsValidCell(board, 0, 0)
					&& IsValidCell(board, 3, 0)
					&& IsValidCell(board, 6, 0)
					&& IsValidCell(board, 0, 3)
					&& IsValidCell(board, 3, 3)
					&& IsValidCell(board, 6, 3)
					&& IsValidCell(board, 0, 6)
					&& IsValidCell(board, 3, 6)
					&& IsValidCell(board, 6, 6);
		}

		private bool IsValidCell(char[][] board, int x, int y)
		{
			var hs = new Dictionary<int, int>();

			for (var i = 0; i < 3; i++)
			{
				for (var j = 0; j < 3; j++)
				{
					if (board[x + i][y + j] != '.')
					{
						var key = int.Parse(board[x + i][y + j].ToString());

						if (!hs.ContainsKey(key))
							hs[key] = 0;

						hs[key]++;
					}
				}
			}

			return hs.All(_ => _.Value == 1);
		}

		private bool IsValidRow(char[][] board, int i)
		{
			var hs = new Dictionary<int, int>();

			for (var j = 0; j < 9; j++)
			{
				if (board[i][j] != '.')
				{
					var key = int.Parse(board[i][j].ToString());

					if (!hs.ContainsKey(key))
						hs[key] = 0;

					hs[key]++;
				}
			}

			return hs.All(_ => _.Value == 1);
		}

		private bool IsValidCol(char[][] board, int i)
		{
			var hs = new Dictionary<int, int>();

			for (var j = 0; j < 9; j++)
			{
				if (board[j][i] != '.')
				{
					var key = int.Parse(board[j][i].ToString());

					if (!hs.ContainsKey(key))
						hs[key] = 0;

					hs[key]++;
				}
			}

			return hs.All(_ => _.Value == 1);
		}
	}
}
