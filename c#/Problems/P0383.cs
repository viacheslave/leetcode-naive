using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/ransom-note/
	///		Submission: https://leetcode.com/submissions/detail/227569167/
	/// </summary>
	internal class P0383
	{
		public bool CanConstruct(string ransomNote, string magazine)
		{
			var map = new Dictionary<char, int>();
			foreach (var ch in magazine)
			{
				if (!map.ContainsKey(ch))
					map[ch] = 0;

				map[ch]++;
			}

			foreach (var ch in ransomNote)
			{
				if (!map.ContainsKey(ch))
					return false;

				map[ch]--;
				if (map[ch] < 0)
					return false;
			}

			return true;
		}
	}
}
