using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/replace-words/
	///		Submission: https://leetcode.com/submissions/detail/235022778/
	/// </summary>
	internal class P0648
	{
		public string ReplaceWords(IList<string> dict, string sentence)
		{
			var words = sentence.Split(' ');

			var newWords = new string[words.Length];

			for (var i = 0; i < words.Length; i++)
			{
				var matched = dict
						.Where(w => words[i].StartsWith(w))
						.OrderBy(_ => _.Length)
						.FirstOrDefault();

				if (matched == null)
					newWords[i] = words[i];
				else
					newWords[i] = matched;
			}

			return string.Join(' ', newWords);
		}
	}
}
