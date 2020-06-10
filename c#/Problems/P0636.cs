using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/exclusive-time-of-functions/
	///		Submission: https://leetcode.com/submissions/detail/280418982/
	/// </summary>
	internal class P0636
	{
		public int[] ExclusiveTime(int n, IList<string> logs)
		{
			var pool = new List<(int functionId, int started)>();
			var ans = new SortedDictionary<int, int>();

			foreach (var log in logs)
			{
				var ps = log.Split(":");

				var id = int.Parse(ps[0]);
				var time = int.Parse(ps[2]);

				if (ps[1] == "start")
				{
					if (pool.Count > 0)
					{
						var top = pool[pool.Count - 1];

						if (!ans.ContainsKey(top.functionId)) ans[top.functionId] = 0;
						ans[top.functionId] += time - top.started;
					}

					pool.Add((id, time));
				}

				if (ps[1] == "end")
				{
					var top = pool[pool.Count - 1];

					if (pool.Count == 1)
					{
						if (!ans.ContainsKey(top.functionId)) ans[top.functionId] = 0;
						ans[top.functionId] += time - top.started + 1;

						pool.Clear();
					}

					if (pool.Count > 1)
					{
						if (top.functionId == id)
						{
							if (!ans.ContainsKey(top.functionId)) ans[top.functionId] = 0;
							ans[top.functionId] += time - top.started + 1;

							pool.RemoveAt(pool.Count - 1);

							pool[pool.Count - 1] = (pool[pool.Count - 1].functionId, time + 1);
						}
						else
						{
							pool.RemoveAll(e => e.functionId == id);
						}
					}
				}
			}

			return ans.Values.ToArray();
		}
	}
}
