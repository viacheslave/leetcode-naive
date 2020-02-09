using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-window-substring/
	///		Submission: https://leetcode.com/submissions/detail/231305668/
	/// </summary>
	internal class P0076
	{
		public string MinWindow(string s, string t)
		{
			var i1 = 0;
			var i2 = 0;

			var maxes = new Dictionary<char, int>();
			foreach (var ti in t)
			{
				if (!maxes.ContainsKey(ti))
					maxes[ti] = 0;
				maxes[ti]++;
			}

			var cd = new Dictionary<char, int>();

			while (i2 < s.Length)
			{
				var ch = s[i2];

				if (!maxes.ContainsKey(ch))
				{
					i2++;
					continue;
				}

				if (!cd.ContainsKey(ch))
					cd[ch] = 0;
				cd[ch]++;

				var full = true;
				foreach (var m in maxes)
					if (!cd.ContainsKey(m.Key) || cd[m.Key] < m.Value)
					{
						full = false;
						break;
					}

				if (!full)
				{
					i2++;
					continue;
				}

				break;
			}

			if (maxes.Count != cd.Count)
				return "";

			foreach (var m in maxes)
				if (cd[m.Key] < m.Value)
					return "";

			// contract left
			while (i1 <= i2)
			{
				var ch = s[i1];
				if (!maxes.ContainsKey(ch))
				{
					i1++; continue;
				}

				if (cd[ch] - 1 >= maxes[ch])
				{
					i1++;
					cd[ch]--; continue;
				}
				break;
			}

			var res = new Dictionary<int, int>();
			res[i1] = i2;

			var left = i1;
			var right = i2;

			// move right
			while (right < s.Length)
			{
				right++;
				if (right == s.Length)
					break;

				var chright = s[right];
				if (cd.ContainsKey(chright))
					cd[chright]++;

				// contract left
				while (left <= right)
				{
					var ch = s[left];
					if (!cd.ContainsKey(ch))
					{
						left++; continue;
					}

					if (cd[ch] - 1 >= maxes[ch])
					{
						left++;
						cd[ch]--; continue;
					}
					break;
				}

				if (left == i1)
				{
					continue;
				}

				res[left] = right;
				i1 = left;
			}

			var rrr = new KeyValuePair<int, int>(0, 0);
			var min = int.MaxValue;

			foreach (var elem in res)
			{
				if (elem.Value - elem.Key < min)
				{
					min = elem.Value - elem.Key;
					rrr = new KeyValuePair<int, int>(elem.Key, elem.Value);
				}
			}

			return s.Substring(rrr.Key, rrr.Value - rrr.Key + 1);
		}
	}
}
