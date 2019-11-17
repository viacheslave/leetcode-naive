using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/game-of-life/
	///		Submission: https://leetcode.com/submissions/detail/227858945/
	/// </summary>
	internal class P0289
	{
		public void GameOfLife(int[][] board)
		{
			var next = new int[board.Length][];

			for (int i = 0; i < board.Length; i++)
			{
				next[i] = new int[board[i].Length];

				for (int j = 0; j < board[i].Length; j++)
				{
					var num = GetNCount(board, i, j);

					if (board[i][j] == 1)
					{
						if (num < 2) next[i][j] = 0;
						else if (num > 3) next[i][j] = 0;
						else next[i][j] = 1;
					}
					else
					{
						if (num == 3) next[i][j] = 1;
					}
				}
			}

			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[i].Length; j++)
				{
					board[i][j] = next[i][j];
				}
			}
		}

		private int GetNCount(int[][] board, int i, int j)
		{
			var neibs = new List<(int, int)>()
				{
						(i - 1, j - 1),
						(i - 1, j),
						(i - 1, j + 1),
						(i,     j + 1),
						(i + 1, j + 1),
						(i + 1, j),
						(i + 1, j - 1),
						(i, j - 1)
				};

			return neibs.Where(_ => IsValid(board, _)).Count();
		}

		private bool IsValid(int[][] board, (int, int) _)
		{
			return _.Item1 >= 0
					&& _.Item2 >= 0
					&& _.Item1 < board.Length
					&& _.Item2 < board[0].Length
					&& board[_.Item1][_.Item2] == 1;
		}
	}
}
