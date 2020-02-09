using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/generate-parentheses/
	///		Submission: https://leetcode.com/submissions/detail/225730106/
	/// </summary>
	internal class P0022
	{
		public IList<string> GenerateParenthesis(int n)
		{
			var res = new List<string>();

			int strlength = n * 2;

			var items = new List<string>();

			Generate(items, new StringBuilder(new string(' ', strlength)), 0, 0);
			return items;

		}

		private void Generate(IList<string> res, StringBuilder current, int index, int opens)
		{
			if (index == current.Length)
			{
				res.Add(current.ToString());
				return;
			}

			if (index == 0)
			{
				current[index] = '(';
				Generate(res, new StringBuilder(current.ToString()), index + 1, opens + 1);
				return;
			}

			if (opens == current.Length / 2)
			{
				current[index] = ')';
				Generate(res, new StringBuilder(current.ToString()), index + 1, opens);
				return;
			}

			if (opens >= (index + 1) / 2)
			{
				current[index] = '(';
				Generate(res, new StringBuilder(current.ToString()), index + 1, opens + 1);

				current[index] = ')';
				Generate(res, new StringBuilder(current.ToString()), index + 1, opens);
				return;
			}
		}
	}
}
