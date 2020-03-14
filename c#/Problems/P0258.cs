using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/add-digits/
	///		Submission: https://leetcode.com/submissions/detail/227158929/
	/// </summary>
	internal class P0258
	{
		public int AddDigits(int num)
		{

			var count = 0;
			var sum = 0;

			do
			{
				var digits = GetDigits(num);

				sum = 0;
				foreach (var digit in digits)
					sum += digit;

				count = sum.ToString().Length;
				num = sum;
			}
			while (count > 1);

			return sum;
		}

		private List<int> GetDigits(int num)
		{
			var power = num.ToString().Length - 1;
			var divisor = (int)Math.Pow(10, power);

			List<int> digits = new List<int>();

			while (num > 0)
			{
				var digit = num / divisor;

				digits.Add(digit);

				num %= divisor;
				divisor /= 10;
			}

			return digits;
		}
	}
}
