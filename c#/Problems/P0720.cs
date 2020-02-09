using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/longest-word-in-dictionary/
	///		Submission: https://leetcode.com/submissions/detail/233397242/
	/// </summary>
	internal class P0720
	{
		public string LongestWord(string[] words)
		{
			var hs = new HashSet<string>(words);
			var arr = words.OrderByDescending(_ => _.Length).ThenBy(_ => _).ToList();

			foreach (var item in arr)
			{
				var sb = new StringBuilder(item);
				while (hs.Contains(sb.ToString()))
					sb.Remove(sb.Length - 1, 1);

				if (sb.ToString() == "")
					return item;
			}

			return string.Empty;
		}
	}
}
