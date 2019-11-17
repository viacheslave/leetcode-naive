using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-common-characters/
	///		Submission: https://leetcode.com/submissions/detail/239326782/
	/// </summary>
	internal class P1002
	{
		public IList<string> CommonChars(string[] A)
		{
			var maps = new List<Dictionary<char, int>>();

			for (var i = 0; i < A.Length; i++)
			{
				var ds = new Dictionary<char, int>();

				foreach (var ch in A[i])
				{
					if (!ds.ContainsKey(ch))
						ds[ch] = 0;

					ds[ch]++;
				}

				maps.Add(ds);
			}

			var template = A[0];
			var res = new List<string>();

			foreach (var ch in template)
			{
				if (maps.All(_ => _.ContainsKey(ch) && _[ch] > 0))
				{
					res.Add(ch.ToString());
					foreach (var map in maps)
						map[ch]--;
				}
			}

			return res;
		}
	}
}
