using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sort-characters-by-frequency/
	///		Submission: https://leetcode.com/submissions/detail/243001256/
	/// </summary>
	internal class P0451
	{
		public string FrequencySort(string s)
		{
			var d = new Dictionary<char, int>();

			for (var i = 0; i < s.Length; i++)
			{
				if (!d.ContainsKey(s[i]))
					d[s[i]] = 0;

				d[s[i]]++;
			}

			var ordered = d.OrderByDescending(item => item.Value).ToList();

			var sb = new StringBuilder();

			foreach (var item in ordered)
			{
				sb.Append(new string(item.Key, item.Value));
			}

			return sb.ToString();
		}
	}
}
