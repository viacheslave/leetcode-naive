using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/
	///		Submission: https://leetcode.com/submissions/detail/387697267/
	/// </summary>
	internal class P1455
	{
		public int IsPrefixOfWord(string sentence, string searchWord)
		{
			var words = sentence.Split(' ');
			for (var i = 0; i < words.Length; i++)
			{
				if (words[i].StartsWith(searchWord))
					return i + 1;
			}

			return -1;
		}
	}
}
