using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/evaluate-reverse-polish-notation/
	///		Submission: https://leetcode.com/submissions/detail/244147568/
	/// </summary>
	internal class P0150
	{
		public int EvalRPN(string[] tokens)
		{
			var st = new Stack<object>();
			var operators = new HashSet<string>() { "+", "-", "*", "/" };

			foreach (var token in tokens)
			{
				if (operators.Contains(token))
				{
					var op2 = (int)st.Pop();
					var op1 = (int)st.Pop();

					switch (token)
					{
						case "+": st.Push(op1 + op2); break;
						case "-": st.Push(op1 - op2); break;
						case "*": st.Push(op1 * op2); break;
						case "/": st.Push(op1 / op2); break;
					}
				}
				else
				{
					st.Push(int.Parse(token));
				}
			}

			return (int)st.Pop();
		}
	}
}
