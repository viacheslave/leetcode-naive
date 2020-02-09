using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-length-of-pair-chain/
	///		Submission: https://leetcode.com/submissions/detail/239722251/
	/// </summary>
	internal class P0646
	{
		public int FindLongestChain(int[][] pairs)
		{
			if (pairs.Length == 0) return 0;

			var map = new SortedDictionary<int, int>();

			foreach (var p in pairs)
			{
				if (map.ContainsKey(p[0]))
				{
					if (map[p[0]] > p[1])
						map[p[0]] = p[1];
				}
				else
				{
					map[p[0]] = p[1];
				}
			}

			var chain = 0;
			var last = -1;

			foreach (var m in map)
			{
				var bef = map
		.Where(_ => m.Key < _.Key && _.Key < m.Value)
		.Where(_ => m.Key < _.Value && _.Value < m.Value)
		.Count();

				if (bef > 0)
					continue;

				if (chain == 0)
				{
					chain++;
					last = m.Value;
					continue;
				}

				if (m.Key <= last)
					continue;

				chain++;
				last = m.Value;
			}

			return chain;
		}
	}
}
