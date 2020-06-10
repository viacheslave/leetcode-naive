using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-boomerangs/
	///		Submission: https://leetcode.com/submissions/detail/289549242/
	/// </summary>
	internal class P0447
	{
		public int NumberOfBoomerangs(int[][] points)
		{
			var dist = new Dictionary<(int, int), double>();

			for (int i = 0; i < points.Length; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					var ydiff = points[j][1] - points[i][1];
					var xdiff = points[j][0] - points[i][0];
					var dis = Math.Sqrt(Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2));

					dist[(i, j)] = dis;
					dist[(j, i)] = dis;
				}
			}

			var gr = dist.GroupBy(x => x.Value).ToDictionary(
					x => x.Key,
					x => x
					.GroupBy(k => k.Key.Item1)
					.Select(g => g.Count())
					.Where(g => g > 1)
					.ToList()
			);

			var ans = 0;

			foreach (var item in gr)
				ans += item.Value.Select(i => i * (i - 1)).Sum();

			return ans;
		}
	}
}
