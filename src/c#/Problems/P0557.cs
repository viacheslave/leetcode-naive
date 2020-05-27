using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reverse-words-in-a-string-iii/
	///		Submission: https://leetcode.com/submissions/detail/230645080/
	/// </summary>
	internal class P0557
	{
		public string ReverseWords(string s)
		{
			var words = s.Split(' ');

			var sb = new StringBuilder();
			var newWords = new string[words.Length];

			for (var i = 0; i < words.Length; i++)
			{
				var wb = new StringBuilder();

				for (var j = 0; j < words[i].Length; j++)
				{
					wb.Append(words[i][words[i].Length - 1 - j]);
				}

				newWords[i] = wb.ToString();
			}

			return string.Join(' ', newWords);
		}
	}
}
