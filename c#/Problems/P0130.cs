using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/surrounded-regions/
	///		Submission: https://leetcode.com/submissions/detail/241502235/
	/// </summary>
	internal class P0130
	{
		public void Solve(char[][] board)
		{
			var visited = new HashSet<(int, int)>();

			for (int i = 1; i < board.Length - 1; i++)
			{
				for (int j = 1; j < board[i].Length - 1; j++)
				{
					if (visited.Contains((i, j)))
						continue;

					if (board[i][j] == 'O')
						Process(board, (i, j), visited);
				}
			}
		}

		private void Process(char[][] board, (int i, int j) p, HashSet<(int, int)> visited)
		{
			var queue = new Queue<(int, int)>();
			queue.Enqueue((p.i, p.j));

			var connectedToBorder = false;
			var localPool = new HashSet<(int, int)>();

			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				if (visited.Contains(item))
					continue;

				visited.Add(item);

				if (IsConnectedToZeroOnBorder(item, board))
				{
					connectedToBorder = true;
				}

				localPool.Add(item);

				var next = (item.Item1 + 1, item.Item2);
				if (IsValid(board, next)) queue.Enqueue(next);

				next = (item.Item1 - 1, item.Item2);
				if (IsValid(board, next)) queue.Enqueue(next);

				next = (item.Item1, item.Item2 + 1);
				if (IsValid(board, next)) queue.Enqueue(next);

				next = (item.Item1, item.Item2 - 1);
				if (IsValid(board, next)) queue.Enqueue(next);
			}

			if (!connectedToBorder)
			{
				foreach (var point in localPool)
				{
					board[point.Item1][point.Item2] = 'X';
				}
			}
		}

		private bool IsConnectedToZeroOnBorder((int i, int j) item, char[][] board)
		{
			return IsZeroOnBorder(board, (item.i + 1, item.j))
				|| IsZeroOnBorder(board, (item.i - 1, item.j))
				|| IsZeroOnBorder(board, (item.i, item.j + 1))
				|| IsZeroOnBorder(board, (item.i, item.j - 1));
		}

		private bool IsZeroOnBorder(char[][] board, (int i, int j) p)
		{
			return (p.i == 0
				|| p.j == 0
				|| p.i == board.Length - 1
				|| p.j == board[0].Length - 1) && board[p.i][p.j] == 'O';
		}

		private bool IsValid(char[][] board, (int i, int j) p)
		{
			return p.i > 0
				&& p.j > 0
				&& p.i < board.Length - 1
				&& p.j < board[0].Length - 1
				&& board[p.i][p.j] == 'O';
		}
	}
}
