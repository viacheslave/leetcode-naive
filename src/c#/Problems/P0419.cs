using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/battleships-in-a-board/
	///		Submission: https://leetcode.com/submissions/detail/239473703/
	/// </summary>
	internal class P0419
	{
		public int CountBattleships(char[][] board)
		{
			var processed = new HashSet<(int, int)>();
			var count = 0;

			for (var i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[i].Length; j++)
				{
					if (board[i][j] == '.')
						continue;

					if (processed.Contains((i, j)))
						continue;

					count++;

					var queue = new Queue<(int, int)>();
					queue.Enqueue((i, j));

					while (queue.Count > 0)
					{
						var item = queue.Dequeue();
						processed.Add(item);

						if (IsEligible(board, (item.Item1 + 1, item.Item2)))
							queue.Enqueue((item.Item1 + 1, item.Item2));

						if (IsEligible(board, (item.Item1, item.Item2 + 1)))
							queue.Enqueue((item.Item1, item.Item2 + 1));
					}
				}
			}

			return count;
		}

		private bool IsEligible(char[][] board, (int, int) p)
		{
			if (p.Item1 >= 0 &&
					p.Item2 >= 0 &&
					p.Item1 < board.Length &&
					p.Item2 < board[0].Length &&
					board[p.Item1][p.Item2] == 'X')
			{
				return true;
			}

			return false;
		}
	}
}
