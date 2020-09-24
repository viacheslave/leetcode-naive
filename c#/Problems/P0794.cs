using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/valid-tic-tac-toe-state/
	///		Submission: https://leetcode.com/submissions/detail/400212633/
	/// </summary>
	internal class P0794
	{
		public bool ValidTicTacToe(string[] board)
		{
			var xs = board.SelectMany(x => x.ToCharArray()).Count(x => x == 'X');
			var os = board.SelectMany(x => x.ToCharArray()).Count(x => x == 'O');

			var valid = (xs == os) || (xs - os == 1);
			if (!valid)
				return false;

			return !(VictoryFor(board, 'X') && VictoryFor(board, 'O'));
		}

		private bool VictoryFor(string[] board, char v)
		{
			var anyRow = board.Any(x => x.All(ch => ch == v));
			if (anyRow)
				return true;

			var anyCol = Enumerable.Range(0, 3).Any(x => board[0][x] == v && board[1][x] == v && board[2][x] == v);
			if (anyCol)
				return true;

			return (board[0][0] == v && board[1][1] == v && board[2][2] == v) ||
					(board[2][0] == v && board[1][1] == v && board[0][2] == v);
		}
	}
}
