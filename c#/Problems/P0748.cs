using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shortest-completing-word/
	///		Submission: https://leetcode.com/submissions/detail/233395678/
	/// </summary>
	internal class P0748
	{
		public string ShortestCompletingWord(string licensePlate, string[] words)
		{
			var basic = GetMap(licensePlate);
			var minword = "";

			foreach (var word in words)
			{
				var v = GetMap(word);
				var ok = true;

				foreach (var b in basic)
					ok = ok && (v.ContainsKey(b.Key) && v[b.Key] >= b.Value);

				if (ok)
				{
					if (minword == "")
						minword = word;
					else if (word.Length < minword.Length)
						minword = word;
				}
			}

			return minword;
		}

		private Dictionary<string, int> GetMap(string word)
		{
			var d = new Dictionary<string, int>();
			foreach (var ch in word)
			{
				if (!Char.IsLetter(ch))
					continue;

				var c = ch.ToString().ToLower();
				if (!d.ContainsKey(c))
					d[c] = 0;
				d[c]++;
			}

			return d;
		}
	}
}
