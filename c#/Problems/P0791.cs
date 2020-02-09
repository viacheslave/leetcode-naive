using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/custom-sort-string/
	///		Submission: https://leetcode.com/submissions/detail/247242954/
	/// </summary>
	internal class P0791
	{
		public string CustomSortString(string S, string T)
		{
			var tmap = T.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());

			var sb = new StringBuilder();

			foreach (var s in S)
			{
				if (tmap.ContainsKey(s))
				{
					sb.Append(new string(Enumerable.Repeat(s, tmap[s]).ToArray()));
					tmap[s] = 0;
				}
			}

			foreach (var t in tmap.Where(_ => _.Value != 0))
			{
				sb.Append(new string(Enumerable.Repeat(t.Key, t.Value).ToArray()));
			}

			return sb.ToString();
		}
	}
}
