using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/alphabet-board-path/
	///		Submission: https://leetcode.com/submissions/detail/246949332/
	/// </summary>
	internal class P1138
	{
		public string AlphabetBoardPath(string target)
		{
			var board = new char[6][]
			{
						new char[] { 'a', 'b', 'c', 'd', 'e' },
						new char[] { 'f', 'g', 'h', 'i', 'j' },
						new char[] { 'k', 'l', 'm', 'n', 'o' },
						new char[] { 'p', 'q', 'r', 's', 't' },
						new char[] { 'u', 'v', 'w', 'x', 'y' },
						new char[] { 'z', '0', '0', '0', '0' }
			};

			if (target.Length == 0)
				return "";

			//target = "a" + target;

			var currentPos = (0, 0);
			var sb = new StringBuilder();

			foreach (var ch in target)
			{
				var path = DFS(board, currentPos, ch);
				sb.Append(path);

				for (int i = 0; i < board.Length; i++)
				{
					for (int j = 0; j < board[0].Length; j++)
					{
						if (board[i][j] == ch)
						{
							currentPos = (i, j);
							break;
						}
					}
				}
			}

			return sb.ToString();
		}

		private string DFS(char[][] board, (int, int) currentPos, char target)
		{
			var visited = new HashSet<(int, int)>();
			var queue = new Queue<(int, int, string)>();

			queue.Enqueue((currentPos.Item1, currentPos.Item2, ""));

			while (queue.Count > 0)
			{
				var point = queue.Dequeue();

				if (board[point.Item1][point.Item2] == target)
				{
					return point.Item3 + "!";
				}

				if (visited.Contains((point.Item1, point.Item2)))
					continue;

				visited.Add((point.Item1, point.Item2));

				var left = (point.Item1, point.Item2 - 1);
				var right = (point.Item1, point.Item2 + 1);
				var up = (point.Item1 - 1, point.Item2);
				var down = (point.Item1 + 1, point.Item2);

				if (Valid(board, left))
					queue.Enqueue((left.Item1, left.Item2, point.Item3 + "L"));
				if (Valid(board, right))
					queue.Enqueue((right.Item1, right.Item2, point.Item3 + "R"));
				if (Valid(board, up))
					queue.Enqueue((up.Item1, up.Item2, point.Item3 + "U"));
				if (Valid(board, down))
					queue.Enqueue((down.Item1, down.Item2, point.Item3 + "D"));
			}

			return "";
		}

		private bool Valid(char[][] board, (int, int) pos)
		{
			return pos.Item1 >= 0
					&& pos.Item2 >= 0
					&& pos.Item1 < board.Length
					&& pos.Item2 < board[0].Length
					&& board[pos.Item1][pos.Item2] != '0';
		}
	}
}
