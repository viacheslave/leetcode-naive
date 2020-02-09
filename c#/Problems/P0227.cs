using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/basic-calculator-ii/
	///		Submission: https://leetcode.com/submissions/detail/241164140/
	/// </summary>
	internal class P0227
	{
		public int Calculate(string s)
		{
			if (!s.StartsWith("+") && !s.StartsWith("-"))
				s = "+" + s;

			var stack = new Stack<string>();

			string lastsign = null;

			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == ' ')
					continue;

				if (!Char.IsDigit(s[i]))
				{
					if (((s[i] == '+' || s[i] == '-') && (lastsign == "*" || lastsign == "/")))
					{
						RewindStack(stack);
					}

					stack.Push(s[i].ToString());
					lastsign = s[i].ToString();
					continue;
				}

				var current = i;
				while (current < s.Length && Char.IsDigit(s[current]))
					current++;

				var str = s.Substring(i, current - i);
				stack.Push(str);

				i += str.Length - 1;
			}

			if (lastsign == "*" || lastsign == "/")
				RewindStack(stack);

			return Calculate(stack);
		}

		private int Calculate(Stack<string> stack)
		{
			var list = new List<string>();

			while (stack.Count > 0)
				list.Add(stack.Pop());

			list.Reverse();

			int operand = 0;
			string op = null;

			for (int i = 0; i < list.Count; i++)
			{
				if (i % 2 == 1)
				{
					if (op != null)
					{
						switch (op)
						{
							case "+": operand += int.Parse(list[i]); break;
							case "-": operand -= int.Parse(list[i]); break;
							case "*": operand *= int.Parse(list[i]); break;
							case "/": operand /= int.Parse(list[i]); break;
						}
					}
					else
					{
						operand = int.Parse(list[i]);
					}
				}
				else
				{
					op = list[i];
				}
			}

			return operand;
		}

		private void RewindStack(Stack<string> stack)
		{
			var list = new List<string>();

			while (stack.Count > 0)
			{
				if (stack.Peek() == "+" || stack.Peek() == "-")
					break;

				list.Add(stack.Pop());
			}

			list.Reverse();

			int operand = 1;
			string op = null;

			for (int i = 0; i < list.Count; i++)
			{
				if (i % 2 == 0)
				{
					if (op != null)
					{
						switch (op)
						{
							case "+": operand += int.Parse(list[i]); break;
							case "-": operand -= int.Parse(list[i]); break;
							case "*": operand *= int.Parse(list[i]); break;
							case "/": operand /= int.Parse(list[i]); break;
						}
					}
					else
					{
						operand = int.Parse(list[i]);
					}
				}
				else
				{
					op = list[i];
				}
			}

			stack.Push(operand.ToString());
		}
	}
}
