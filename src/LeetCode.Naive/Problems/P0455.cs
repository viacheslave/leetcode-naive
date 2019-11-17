using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/assign-cookies/
	///		Submission: https://leetcode.com/submissions/detail/237986990/
	/// </summary>
	internal class P0455
	{
		public int FindContentChildren(int[] g, int[] s)
		{
			if (g.Length == 0 || s.Length == 0)
				return 0;

			Array.Sort(g);
			Array.Sort(s);

			var gi = 0;
			var si = 0;

			var satisfied = 0;
			while (gi < g.Length)
			{
				if (si >= s.Length)
					break;

				var gr = g[gi];
				var sr = s[si];

				if (gr <= sr)
				{
					satisfied++;
					si++;
					gi++;
					continue;
				}

				while (si < s.Length && s[si] < gr)
					si++;
			}

			return satisfied;
		}
	}
}
