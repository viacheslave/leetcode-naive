using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rearrange-words-in-a-sentence/
	///		Submission: https://leetcode.com/submissions/detail/344566977/
	/// </summary>
	internal class P1451
	{
		public string ArrangeWords(string text)
		{
			var words = text.Split(' ').Select(w => w.ToLowerInvariant()).OrderBy(x => x.Length);
			var newtext = string.Join(' ', words);

			var sb = new StringBuilder(newtext);
			sb[0] = Char.ToUpper(newtext[0]);

			return sb.ToString();
		}
	}
}
