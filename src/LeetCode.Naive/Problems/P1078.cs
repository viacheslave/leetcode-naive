using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/occurrences-after-bigram/
	///		Submission: https://leetcode.com/submissions/detail/234779816/
	/// </summary>
	internal class P1078
	{
		public string[] FindOcurrences(string text, string first, string second)
		{
			var words = text.Split(' ').ToArray();
			var res = new List<string>();

			for (var i = 0; i < words.Length; i++)
			{
				if (words[i] == first)
				{
					if (i + 1 < words.Length && words[i + 1] == second)
					{
						if (i + 2 < words.Length)
						{
							res.Add(words[i + 2]);
						}
					}
				}
			}

			return res.ToArray();
		}
	}
}
