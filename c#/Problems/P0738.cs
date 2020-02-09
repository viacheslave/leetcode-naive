using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/monotone-increasing-digits/
	///		Submission: https://leetcode.com/submissions/detail/244067376/
	/// </summary>
	internal class P0738
	{
		public int MonotoneIncreasingDigits(int N)
		{
			var str = N.ToString();

			if (str.Length == 1)
				return N;

			var digits = str.ToCharArray().Select(_ => int.Parse(_.ToString())).ToList();

			int index = 0;

			while (index < digits.Count - 1)
			{
				var right = digits[digits.Count - 1 - index];
				var left = digits[digits.Count - 1 - index - 1];

				if (right < left)
				{
					var currentValue = int.Parse(string.Join("", digits));
					int pow = (int)Math.Pow(10, index + 1);
					currentValue = (currentValue / pow) * pow;
					currentValue -= 1;

					digits = currentValue.ToString().ToCharArray().Select(_ => int.Parse(_.ToString())).ToList();
				}

				index++;
			}

			return int.Parse(string.Join("", digits));
		}
	}
}
