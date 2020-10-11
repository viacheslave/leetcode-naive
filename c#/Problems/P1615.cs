using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximal-network-rank/
	///		Submission: https://leetcode.com/submissions/detail/407338932/
	/// </summary>
	internal class P1615
	{
		public int MaximalNetworkRank(int n, int[][] roads)
		{
			var paths = new Dictionary<int, HashSet<int>>();

			foreach (var road in roads)
			{
				var from = road[0];
				var to = road[1];

				if (!paths.ContainsKey(from))
					paths[from] = new HashSet<int>();

				if (!paths.ContainsKey(to))
					paths[to] = new HashSet<int>();

				paths[from].Add(to);
				paths[to].Add(from);
			}

			var ans = 0;

			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					if (i == j)
						continue;

					var count = 0;

					if (paths.TryGetValue(i, out var outi))
						count += outi.Count;

					if (paths.TryGetValue(j, out var outj))
						count += outj.Count;

					if (count > 0)
					{
						if (paths.ContainsKey(i) && paths[i].Contains(j))
							count--;
					}

					ans = Math.Max(ans, count);
				}
			}

			return ans;
		}
	}
}
