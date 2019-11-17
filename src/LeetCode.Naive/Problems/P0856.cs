using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/score-of-parentheses/
	///		Submission: https://leetcode.com/submissions/detail/239976930/
	/// </summary>
	internal class P0856
	{
		public int ScoreOfParentheses(string S)
		{
			// (()(()))

			var stack = new Stack<int>();
			var score = 0;

			for (int i = 0; i < S.Length; i++)
			{
				var ch = S[i];

				if (ch == '(')
				{
					stack.Push(score);
					score = 0;
				}

				if (ch == ')')
				{
					var popScore = stack.Pop();
					score = popScore + (score == 0 ? 1 : score * 2);
				}
			}

			return score;
		}
	}
}
