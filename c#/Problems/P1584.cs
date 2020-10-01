using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/min-cost-to-connect-all-points/
	///		Submission: https://leetcode.com/submissions/detail/403144428/
	/// </summary>
	internal class P1584
	{
		public int MinCostConnectPoints(int[][] points)
		{
			var edges = new List<(int p1, int p2, int distance)>();

			for (var i = 0; i < points.Length; i++)
			{
				for (var j = i + 1; j < points.Length; j++)
				{
					edges.Add((i, j,
							Math.Abs(points[j][0] - points[i][0]) +
							Math.Abs(points[j][1] - points[i][1])));
				}
			}

			edges = edges.OrderBy(e => e.distance)
					.ToList();

			var distances = new List<int>();

			var sets = Enumerable.Range(0, points.Length)
					.Select(p => (value: p, rank: 0))
					.ToList();

			foreach (var edge in edges)
			{
				var space1 = Find(sets, edge.p1);
				var space2 = Find(sets, edge.p2);

				if (space1 == space2)
					continue;

				distances.Add(edge.distance);
				Union(sets, edge.p1, edge.p2);
			}

			return distances.Sum();
		}

		private int Find(List<(int value, int rank)> sets, int p1)
		{
			if (sets[p1].value != p1)
			{
				var value = Find(sets, sets[p1].value);
				sets[p1] = (value, sets[p1].rank);
			}

			return sets[p1].value;
		}

		private void Union(List<(int value, int rank)> sets, int p1, int p2)
		{
			var value1 = Find(sets, p1);
			var value2 = Find(sets, p2);

			if (sets[value1].rank < sets[value2].rank)
			{
				sets[value1] = (value2, sets[value1].rank);
			}
			else if (sets[value1].rank > sets[value2].rank)
			{
				sets[value2] = (value1, sets[value2].rank);
			}
			else
			{
				sets[value1] = (value2, sets[value1].rank);
				sets[value2] = (sets[value2].value, sets[value2].rank + 1);
			}
		}
	}
}
