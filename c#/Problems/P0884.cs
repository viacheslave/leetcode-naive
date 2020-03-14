using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/uncommon-words-from-two-sentences/
	///		Submission: https://leetcode.com/submissions/detail/231090206/
	/// </summary>
	internal class P0884
	{
		public string[] UncommonFromSentences(string A, string B)
		{
			var d = new Dictionary<string, int>();

			foreach (var word in A.Split(' ').Where(_ => _ != string.Empty))
			{
				if (!d.ContainsKey(word))
					d[word] = 0;

				d[word]++;
			}

			foreach (var word in B.Split(' ').Where(_ => _ != string.Empty))
			{
				if (!d.ContainsKey(word))
					d[word] = 0;

				d[word]++;
			}

			return d.Where(_ => _.Value == 1).Select(_ => _.Key).ToArray();
		}
	}
}
