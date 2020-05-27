using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-numbers-with-unique-digits/
	///		Submission: https://leetcode.com/submissions/detail/235201507/
	/// </summary>
	internal class P0357
	{
		public int CountNumbersWithUniqueDigits(int n)
		{
			if (n > 10)
				return 0;

			var count = 0;
			for (var i = n; i >= 0; i--)
				count = count + GetFor(i + 1);

			return count;
		}

		public int GetFor(int n)
		{
			if (n == 1)
				return 1;

			var main = 9;
			for (var i = 0; i < n - 2; i++)
				main = main * (9 - i);

			return main;
		}
	}
}
