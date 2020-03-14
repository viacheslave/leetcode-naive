using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/
	///		Submission: https://leetcode.com/submissions/detail/299919883/
	/// </summary>
	internal class P1209
	{
		public string RemoveDuplicates(string s, int k)
		{
			var st = new Stack<(char, int)>();

			for (int i = 0; i < s.Length; i++)
			{
				if (st.Count == 0)
				{
					st.Push((s[i], 1));
					continue;
				}

				var last = st.Peek();
				if (last.Item1 == s[i])
					st.Push((s[i], last.Item2 + 1));
				else
					st.Push((s[i], 1));

				if (st.Peek().Item2 == k)
				{
					for (int j = 0; j < k; j++)
					{
						st.Pop();
					}
				}
			}

			var sb = new List<char>();
			while (st.Count > 0)
				sb.Add(st.Pop().Item1);

			sb.Reverse();
			return new string(sb.ToArray());
		}
	}
}
