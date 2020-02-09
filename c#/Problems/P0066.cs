using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/plus-one/
	///		Submission: https://leetcode.com/submissions/detail/226366718/
	/// </summary>
	internal class P0066
	{
		public int[] PlusOne(int[] digits)
		{
			var carry = false;

			var sum = digits[digits.Length - 1] + 1;

			digits[digits.Length - 1] = sum % 10;

			carry = sum >= 10;

			var index = digits.Length - 2;

			while (carry)
			{
				if (index < 0)
				{
					var l = new List<int> { 1 };
					l.AddRange(digits);
					return l.ToArray();
				}

				sum = digits[index] + 1;
				digits[index] = sum % 10;
				carry = sum >= 10;

				index = index - 1;
			}

			return digits;
		}
	}
}
