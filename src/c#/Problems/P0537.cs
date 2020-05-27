using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/complex-number-multiplication/
	///		Submission: https://leetcode.com/submissions/detail/234938784/
	/// </summary>
	internal class P0537
	{
		public string ComplexNumberMultiply(string a, string b)
		{
			var n1 = GetCoeff(a);
			var n2 = GetCoeff(b);

			var real = n1.Item1 * n2.Item1 - n1.Item2 * n2.Item2;
			var img = n1.Item1 * n2.Item2 + n1.Item2 * n2.Item1;

			return $"{real}+{img}i";
		}

		private (int, int) GetCoeff(string s)
		{
			var rp = s.Split(new[] { '+' });
			return (int.Parse(rp[0]), int.Parse(rp[1].TrimEnd(new[] { 'i' })));
		}
	}
}
