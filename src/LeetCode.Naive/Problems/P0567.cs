using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/permutation-in-string/
	///		Submission: https://leetcode.com/submissions/detail/232014873/
	/// </summary>
	internal class P0567
	{
		public bool CheckInclusion(string s1, string s2)
		{
			var pd = new Dictionary<char, int>();
			foreach (var ch in s1)
			{
				if (!pd.ContainsKey(ch))
					pd[ch] = 0;
				pd[ch]++;
			}

			if (s1.Length > s2.Length)
				return false;

			var window = new Dictionary<char, int>();
			for (var i = 0; i < s1.Length; i++)
			{
				if (!window.ContainsKey(s2[i]))
					window[s2[i]] = 0;
				window[s2[i]]++;
			}

			var start = 0;
			var end = s1.Length - 1;

			var result = new List<int>();

			while (end < s2.Length)
			{
				var fits = Fits(pd, window);
				if (fits)
					return true;

				if (end != s2.Length - 1)
				{
					window[s2[start]]--;
					if (window[s2[start]] == 0)
						window.Remove(s2[start]);

					if (!window.ContainsKey(s2[end + 1]))
						window[s2[end + 1]] = 0;

					window[s2[end + 1]]++;
				}

				start++;
				end++;
			}

			return false;
		}

		private bool Fits(Dictionary<char, int> pd, Dictionary<char, int> window)
		{
			if (pd.Count != window.Count)
				return false;

			foreach (var pch in pd)
			{
				if (!window.ContainsKey(pch.Key))
					return false;

				if (window[pch.Key] != pch.Value)
					return false;
			}

			return true;
		}
	}
}
