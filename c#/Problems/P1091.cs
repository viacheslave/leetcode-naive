using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shortest-path-in-binary-matrix/
	///		Submission: https://leetcode.com/contest/weekly-contest-141/submissions/detail/236207067/
	/// </summary>
	internal class P1091
	{
		public int ShortestPathBinaryMatrix(int[][] grid)
		{
			var hs = new HashSet<(int, int)>();
			var q = new Queue<(int, int, int)>();
			var min = int.MaxValue;

			q.Enqueue((0, 0, 1));

			while (q.Count > 0)
			{
				var el = q.Dequeue();

				if (el.Item1 < 0 || el.Item2 < 0 || el.Item1 >= grid.Length || el.Item2 >= grid.Length)
					continue;

				if (grid[el.Item1][el.Item2] == 1)
					continue;

				if (hs.Contains((el.Item1, el.Item2)))
					continue;

				hs.Add((el.Item1, el.Item2));

				if (el.Item1 == grid.Length - 1 && el.Item2 == grid.Length - 1)
				{
					if (el.Item3 < min) min = el.Item3;
					continue;
				}

				q.Enqueue((el.Item1 + 1, el.Item2 - 1, el.Item3 + 1));
				q.Enqueue((el.Item1 + 1, el.Item2 + 0, el.Item3 + 1));
				q.Enqueue((el.Item1 + 1, el.Item2 + 1, el.Item3 + 1));
				q.Enqueue((el.Item1 + 0, el.Item2 - 1, el.Item3 + 1));
				q.Enqueue((el.Item1 + 0, el.Item2 + 1, el.Item3 + 1));
				q.Enqueue((el.Item1 - 1, el.Item2 + 0, el.Item3 + 1));
				q.Enqueue((el.Item1 - 1, el.Item2 + 1, el.Item3 + 1));
			}

			return min == int.MaxValue ? -1 : min;
		}
	}
}
