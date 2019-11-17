using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/repeated-dna-sequences/
	///		Submission: https://leetcode.com/submissions/detail/238608929/
	/// </summary>
	internal class P0187
	{
		public IList<string> FindRepeatedDnaSequences(string s)
		{
			var map = new Dictionary<string, int>();

			for (var i = 0; i < s.Length - 10 + 1; i++)
			{
				var sub = s.Substring(i, 10);
				if (!map.ContainsKey(sub)) map[sub] = 0;
				map[sub]++;
			}

			return map.Where(_ => _.Value > 1).Select(_ => _.Key).ToList();
		}

	}
}
