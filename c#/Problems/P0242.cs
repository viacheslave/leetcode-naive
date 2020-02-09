using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/valid-anagram/
	///		Submission: https://leetcode.com/submissions/detail/228892860/
	/// </summary>
	internal class P0242
	{
		public bool IsAnagram(string s, string t)
		{
			var s1 = GetSum(s);
			var s2 = GetSum(t);

			if (s1.Count() != s2.Count())
				return false;

			foreach (var k in s1)
			{
				if (!s2.ContainsKey(k.Key))
					return false;

				var l = s2[k.Key];
				if (k.Value != l)
					return false;
			}

			return true;
		}

		private Dictionary<char, int> GetSum(string s)
		{
			var d = new Dictionary<char, int>();
			foreach (var ch in s)
			{
				if (!d.ContainsKey(ch))
					d.Add(ch, 0);

				d[ch]++;
			}

			return d;
		}
	}
}
