using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/backspace-string-compare/
	///		Submission: https://leetcode.com/submissions/detail/233821022/
	/// </summary>
	internal class P0844
	{
		public bool BackspaceCompare(string S, string T)
		{
			var f1 = GetFinal(S);
			var f2 = GetFinal(T);

			return f1 == f2;
		}

		public string GetFinal(string s)
		{
			var sb = new StringBuilder();

			for (var i = 0; i < s.Length; i++)
			{
				if (s[i] != '#')
				{
					sb.Append(s[i]);
					continue;
				}

				if (sb.Length > 0)
					sb.Remove(sb.Length - 1, 1);
			}

			return sb.ToString();
		}
	}
}
