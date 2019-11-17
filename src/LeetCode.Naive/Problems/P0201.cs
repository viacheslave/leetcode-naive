using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/bitwise-and-of-numbers-range/
	///		Submission: https://leetcode.com/submissions/detail/241213858/
	/// </summary>
	internal class P0201
	{
		public int RangeBitwiseAnd(int m, int n)
		{
			var number = 0;

			for (int i = 0; i < 31; i++)
			{
				var digit = GetDigit(m, n, i);
				number += (digit == 0) ? 0 : (int)Math.Pow(2, i);
			}

			return number;
		}

		private int GetDigit(int m, int n, int digit)
		{
			var powered = (int)Math.Pow(2, digit);

			if (n - m + 1 > powered)
				return 0;

			return (
					(m % (powered * 2) >= powered) && (n % (powered * 2) >= powered)) ? 1 : 0;
		}
	}
}
