using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/compare-strings-by-frequency-of-the-smallest-character/
	///		Submission: https://leetcode.com/submissions/detail/279298315/
	/// </summary>
	internal class P1170
	{
		public int[] NumSmallerByFrequency(string[] queries, string[] words)
		{
			var q = new int[queries.Length];
			var w = new int[words.Length];

			for (int i = 0; i < queries.Length; i++)
				q[i] = f(queries[i]);

			for (int i = 0; i < words.Length; i++)
				w[i] = f(words[i]);

			var ans = new int[q.Length];

			for (int i = 0; i < queries.Length; i++)
			{
				ans[i] = w.Count(wi => wi > q[i]);
			}

			return ans;
		}

		private int f(string word)
		{
			var minCh = word.ToCharArray().Min(ch => (int)ch);
			return word.Count(ch => ch == minCh);
		}
	}
}
