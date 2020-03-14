using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/first-unique-character-in-a-string/
	///		Submission: https://leetcode.com/submissions/detail/231068513/
	/// </summary>
	internal class P0387
	{
		public int FirstUniqChar(string s)
		{
			var d = new Dictionary<char, int>();

			for (var i = 0; i < s.Length; i++)
			{
				if (!d.ContainsKey(s[i]))
					d[s[i]] = 0;

				d[s[i]]++;
			}

			var pos = -1;

			for (var i = 0; i < s.Length; i++)
			{
				if (d[s[i]] > 1)
					continue;

				pos = i;
				break;
			}

			return pos;
		}
	}
}
