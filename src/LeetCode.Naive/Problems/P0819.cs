using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/most-common-word/
	///		Submission: https://leetcode.com/submissions/detail/228452982/
	/// </summary>
	internal class P0819
	{
		public string MostCommonWord(string paragraph, string[] banned)
		{
			var words = paragraph.Split(new char[] { ' ', ',', ';', '!', '?', '`', '.', '\'' });

			var d = new Dictionary<string, int>();
			var b = new HashSet<string>(banned);

			foreach (var word in words)
			{
				var lword = word
						.TrimEnd(new char[] { ',', '.', ';', '!', '?', '`', '\'' })
						.ToLower();

				if (lword == "")
					continue;

				if (b.Contains(lword))
					continue;

				if (!d.ContainsKey(lword))
					d[lword] = 0;

				d[lword]++;
			}

			var maxWord = 0;
			var result = "";

			foreach (var word in d)
			{
				if (word.Value > maxWord)
				{
					maxWord = word.Value;
					result = word.Key;
				}
			}

			return result;
		}
	}
}
