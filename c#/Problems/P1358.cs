using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/
	///		Submission: https://leetcode.com/submissions/detail/308044604/
	/// </summary>
	internal class P1358
	{
		public int NumberOfSubstrings(string s)
		{
			var ans = 0;

			var start = 0;
			var end = 0;

			var d = new Dictionary<char, int>();
			d[s[0]] = 1;

			while (start < s.Length - 2)
			{
				while (d.Count < 3)
				{
					end++;
					if (end == s.Length)
						break;

					if (!d.ContainsKey(s[end])) d[s[end]] = 1;
					else d[s[end]]++;
				}

				if (end == s.Length)
					break;

				ans += (s.Length - end);

				d[s[start]]--;
				if (d[s[start]] == 0)
					d.Remove(s[start]);

				start++;
			}

			return ans;
		}
	}
}
