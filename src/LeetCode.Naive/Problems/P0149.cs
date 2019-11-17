using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/max-points-on-a-line/
	///		Submission: https://leetcode.com/submissions/detail/240558615/
	/// </summary>
	internal class P0149
	{
		public int MaxPoints(int[][] points)
		{
			if (points.Length == 0)
				return 0;

			if (points.Length == 1)
				return 1;

			var map = new Dictionary<(decimal, decimal, decimal), HashSet<int>>();

			for (int i = 0; i < points.Length; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					var p1 = points[i];
					var p2 = points[j];

					var k = decimal.MinValue;
					var c = decimal.MinValue;
					var x = decimal.MinValue;

					if (p1[0] == p2[0] && p1[1] == p2[1])
					{
						continue;
					}
					else
					if (p1[0] == p2[0]) // x equal
					{
						x = p1[0];
					}
					else if (p1[1] == p2[1])
					{
						k = 0;
						c = p1[1];
					}
					else
					{
						k = 1.0m * (p2[1] - p1[1]) / (p2[0] - p1[0]);
						c = p2[1] - k * p2[0];
					}

					if (!map.ContainsKey((k, c, x)))
						map[(k, c, x)] = new HashSet<int>();

					map[(k, c, x)].Add(i);
					map[(k, c, x)].Add(j);
				}
			}

			//var ordered = map.OrderByDescending(_ => _.Value.Count).ToList();

			return map.Count == 0
				? points.Length
				: map.OrderByDescending(_ => _.Value.Count).First().Value.Count;
		}
	}
}
