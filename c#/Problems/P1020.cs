using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-enclaves/
	///		Submission: https://leetcode.com/submissions/detail/240530379/
	/// </summary>
	internal class P1020
	{
		public int NumEnclaves(int[][] A)
		{
			var rows = A.Length;
			var cols = A[0].Length;

			var ones = 0;
			for (int i = 0; i < rows; i++)
				for (int j = 0; j < cols; j++)
					if (A[i][j] == 1)
						ones++;

			var queue = new Queue<(int, int)>();

			for (int i = 0; i < rows; i++)
			{
				if (A[i][0] == 1) queue.Enqueue((i, 0));
				if (A[i][cols - 1] == 1) queue.Enqueue((i, cols - 1));
			}

			for (int j = 0; j < cols; j++)
			{
				if (A[0][j] == 1) queue.Enqueue((0, j));
				if (A[rows - 1][j] == 1) queue.Enqueue((rows - 1, j));
			}

			var visited = new HashSet<(int, int)>();

			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				if (visited.Contains(item))
					continue;

				visited.Add(item);

				if (IsValid((item.Item1 + 1, item.Item2), A, rows, cols))
					queue.Enqueue((item.Item1 + 1, item.Item2));
				if (IsValid((item.Item1 - 1, item.Item2), A, rows, cols))
					queue.Enqueue((item.Item1 - 1, item.Item2));
				if (IsValid((item.Item1, item.Item2 + 1), A, rows, cols))
					queue.Enqueue((item.Item1, item.Item2 + 1));
				if (IsValid((item.Item1, item.Item2 - 1), A, rows, cols))
					queue.Enqueue((item.Item1, item.Item2 - 1));
			}

			return ones - visited.Count;
		}

		private bool IsValid((int, int) p, int[][] a, int rows, int cols)
		{
			return p.Item1 >= 0
					&& p.Item2 >= 0
					&& p.Item1 < rows
					&& p.Item2 < cols
					&& a[p.Item1][p.Item2] == 1
					;
		}
	}
}
