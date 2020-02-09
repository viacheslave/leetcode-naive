using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
	///		Submission: https://leetcode.com/submissions/detail/239778418/
	/// </summary>
	internal class P0921
	{
		public int MinAddToMakeValid(string S)
		{
			var st = new Stack<char>();
			var count = 0;

			for (int i = 0; i < S.Length; i++)
			{
				if (S[i] == '(')
				{
					st.Push('(');
				}

				if (S[i] == ')')
				{
					if (st.Count == 0 || st.Peek() == ')')
					{
						count++;
						continue;
					}

					st.Pop();
				}
			}

			return count + st.Count;
		}
	}
}
