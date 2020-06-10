using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/word-search/
	///		Submission: https://leetcode.com/submissions/detail/241015558/
	/// </summary>
	internal class P0079
	{
		public bool Exist(char[][] board, string word)
		{
			if (board.Length == 0 || word.Length == 0)
				return false;

			var startPoints = new List<(int, int)>();
			for (int i = 0; i < board.Length; i++)
				for (int j = 0; j < board[i].Length; j++)
					if (word[0] == board[i][j])
						startPoints.Add((i, j));

			foreach (var point in startPoints)
			{
				var visited = new HashSet<(int, int)>();

				if (Exists(visited, point, board, word, 0))
					return true;
			}

			return false;
		}

		private bool Exists(HashSet<(int, int)> visited, (int, int) point, char[][] board, string word, int index)
		{
			if (index == word.Length || word.Length == 1)
				return true;

			if (visited.Contains(point) || board[point.Item1][point.Item2] != word[index])
				return false;

			visited.Add(point);

			var exists = false;

			var next = (point.Item1 + 1, point.Item2);
			if (IsValid(board, next))
				exists = exists || Exists(visited, next, board, word, index + 1);

			next = (point.Item1 - 1, point.Item2);
			if (IsValid(board, next))
				exists = exists || Exists(visited, next, board, word, index + 1);

			next = (point.Item1, point.Item2 + 1);
			if (IsValid(board, next))
				exists = exists || Exists(visited, next, board, word, index + 1);

			next = (point.Item1, point.Item2 - 1);
			if (IsValid(board, next))
				exists = exists || Exists(visited, next, board, word, index + 1);

			visited.Remove(point);

			return exists;
		}

		private bool IsValid(char[][] board, (int, int) next)
		{
			return next.Item1 >= 0
					&& next.Item2 >= 0
					&& next.Item1 < board.Length
					&& next.Item2 < board[0].Length;
		}
	}
}
