using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/
	///		Submission: https://leetcode.com/submissions/detail/407335024/
	/// </summary>
	internal class P1614
	{
		public int MaxDepth(string s)
		{
			var ans = 0;

			Stack<char> st = new Stack<char>();

			for (var i = 0; i < s.Length; i++)
			{
				if (s[i] == '(')
				{
					st.Push('(');
					ans = Math.Max(st.Count, ans);
				}
				else if (s[i] == ')')
				{
					st.Pop();
				}
			}

			return ans;
		}
	}
}
