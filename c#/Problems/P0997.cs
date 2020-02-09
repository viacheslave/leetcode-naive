using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-the-town-judge/
	///		Submission: https://leetcode.com/submissions/detail/234422943/
	/// </summary>
	internal class P0997
	{
		public int FindJudge(int N, int[][] trust)
		{
			if (N == 1)
				return 1;

			var fr = new Dictionary<int, int>();
			var to = new Dictionary<int, int>();

			for (var i = 0; i < trust.Length; i++)
			{
				if (!to.ContainsKey(trust[i][1]))
					to[trust[i][1]] = 0;

				to[trust[i][1]]++;

				if (!fr.ContainsKey(trust[i][0]))
					fr[trust[i][0]] = 0;

				fr[trust[i][0]]++;
			}

			var items = to
					.Where(_ => _.Value == N - 1 && !fr.ContainsKey(_.Key))
					.ToList();

			return (items.Count > 0) ? items.First().Key : -1;
		}
	}
}
