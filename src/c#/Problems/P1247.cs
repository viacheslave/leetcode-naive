using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-swaps-to-make-strings-equal/
	///		Submission: https://leetcode.com/submissions/detail/278812785/
	/// </summary>
	internal class P1247
	{
		public int MinimumSwap(string s1, string s2)
		{
			var ind = new List<int>();

			for (int i = 0; i < s1.Length; i++)
				if (s1[i] != s2[i])
					ind.Add(i);

			var ans = 0;

			var dirs = new List<int>();
			for (int i = 0; i < ind.Count; i++)
			{
				var index = ind[i];
				if (s1[index] == 'x') dirs.Add(0);
				else dirs.Add(1);
			}

			var zeros = dirs.Count(x => x == 0);
			ans += zeros / 2;

			var ones = dirs.Count(x => x == 1);
			ans += ones / 2;

			zeros = zeros % 2;
			ones = ones % 2;

			if (zeros == 1 && ones == 1)
			{
				ans += 2;
				return ans;
			}

			if (zeros == 0 && ones == 0)
				return ans;

			return -1;
		}
	}
}
