using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/is-graph-bipartite/
	///		Submission: https://leetcode.com/submissions/detail/400183604/
	/// </summary>
	internal class P0785
	{
		public bool IsBipartite(int[][] graph)
		{
			var pool = graph
				.Select((x, i) => (x, i))
				.OrderByDescending(x => x.x.Length)
				.ToDictionary(x => x.i, x => x.x);

			var nodes = new Dictionary<int, bool>();

			var q = new Queue<(int key, bool color)>();
			q.Enqueue((key: pool.First().Key, color: true));

			while (q.Count > 0)
			{
				var item = q.Dequeue();
				if (nodes.ContainsKey(item.key))
				{
					if (nodes[item.key] == item.color)
						continue;

					return false;
				}

				var edges = pool[item.key];

				nodes[item.key] = item.color;

				foreach (var edge in pool[item.key])
				{
					q.Enqueue((edge, !item.color));
				}
			}

			return true;
		}
	}
}
