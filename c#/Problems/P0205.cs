using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/isomorphic-strings/
	///		Submission: https://leetcode.com/submissions/detail/227828310/
	/// </summary>
	internal class P0205
	{
		public bool IsIsomorphic(string s, string t)
		{
			var map = new Dictionary<char, char>();
			var taken = new HashSet<char>();

			for (var i = 0; i < s.Length; i++)
			{
				if (!map.ContainsKey(s[i]))
				{
					if (taken.Contains(t[i]))
						return false;

					map.Add(s[i], t[i]);
					taken.Add(t[i]);
					continue;
				}

				if (map[s[i]] != t[i])
					return false;
			}

			return true;
		}
	}
}
