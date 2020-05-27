using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/01-matrix/
	///		Submission: https://leetcode.com/submissions/detail/241709482/
	/// </summary>
	internal class P0542
	{
		public int[][] UpdateMatrix(int[][] matrix)
		{
			var queue = new Queue<(int, int, int)>();

			for (int i = 0; i < matrix.Length; i++)
				for (int j = 0; j < matrix[i].Length; j++)
					if (matrix[i][j] == 0)
						queue.Enqueue((i, j, 0));

			var visited = new HashSet<(int, int)>();

			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				var cell = (item.Item1, item.Item2);

				if (visited.Contains(cell))
					continue;

				visited.Add(cell);

				matrix[cell.Item1][cell.Item2] = item.Item3;

				var next = (item.Item1 + 1, item.Item2);
				if (IsValid(matrix, next))
					queue.Enqueue((next.Item1, next.Item2, matrix[cell.Item1][cell.Item2] + GetLevel(matrix, next)));

				next = (item.Item1 - 1, item.Item2);
				if (IsValid(matrix, next))
					queue.Enqueue((next.Item1, next.Item2, matrix[cell.Item1][cell.Item2] + GetLevel(matrix, next)));

				next = (item.Item1, item.Item2 + 1);
				if (IsValid(matrix, next))
					queue.Enqueue((next.Item1, next.Item2, matrix[cell.Item1][cell.Item2] + GetLevel(matrix, next)));

				next = (item.Item1, item.Item2 - 1);
				if (IsValid(matrix, next))
					queue.Enqueue((next.Item1, next.Item2, matrix[cell.Item1][cell.Item2] + GetLevel(matrix, next)));
			}

			return matrix;
		}

		private bool IsValid(int[][] matrix, (int, int) cell)
		{
			return cell.Item1 >= 0
					&& cell.Item2 >= 0
					&& cell.Item1 < matrix.Length
					&& cell.Item2 < matrix[0].Length
					&& matrix[cell.Item1][cell.Item2] != 0;
		}

		private int GetLevel(int[][] matrix, (int, int) next)
		{
			return matrix[next.Item1][next.Item2] == 1 ? 1 : 0;
		}
	}
}
