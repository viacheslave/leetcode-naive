using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/keyboard-row/
	///		Submission: https://leetcode.com/submissions/detail/227827010/
	/// </summary>
	internal class P0500
	{
		Dictionary<char, int> letters = new Dictionary<char, int>
		{
			['q'] = 1,
			['w'] = 1,
			['e'] = 1,
			['r'] = 1,
			['t'] = 1,
			['y'] = 1,
			['u'] = 1,
			['i'] = 1,
			['o'] = 1,
			['p'] = 1,

			['a'] = 2,
			['s'] = 2,
			['d'] = 2,
			['f'] = 2,
			['g'] = 2,
			['h'] = 2,
			['j'] = 2,
			['k'] = 2,
			['l'] = 2,

			['z'] = 3,
			['x'] = 3,
			['c'] = 3,
			['v'] = 3,
			['b'] = 3,
			['n'] = 3,
			['m'] = 3
		};

		public string[] FindWords(string[] words)
		{
			var result = new List<string>();

			foreach (var word in words)
			{
				var rows = GetRows(word);
				if (rows.Count == 1)
					result.Add(word);
			}

			return result.ToArray();
		}

		private HashSet<int> GetRows(string word)
		{
			var set = new HashSet<int>();
			foreach (var ch in word)
			{
				set.Add(letters[Char.ToLower(ch)]);
			}
			return set;
		}
	}
}
