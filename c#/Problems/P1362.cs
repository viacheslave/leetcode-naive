using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/closest-divisors/
	///		Submission: https://leetcode.com/submissions/detail/308036815/
	/// </summary>
	internal class P1362
	{
		public int[] ClosestDivisors(int num)
		{
			var num1 = GetDiv(num + 1);
			var num2 = GetDiv(num + 2);

			if (Math.Abs(num1.Item1 - num1.Item2) < Math.Abs(num2.Item1 - num2.Item2))
				return new[] { num1.Item1, num1.Item2 };
			else
				return new[] { num2.Item1, num2.Item2 };
		}

		private (int, int) GetDiv(int num)
		{
			var n = 1;

			for (var i = 1; i <= (int)Math.Sqrt(num); i++)
			{
				if (num % i == 0)
					n = i;
			}

			return (n, num / n);
		}
	}
}
