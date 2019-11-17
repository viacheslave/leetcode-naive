using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/factorial-trailing-zeroes/
	///		Submission: https://leetcode.com/submissions/detail/230221007/
	/// </summary>
	internal class P0172
	{
		public int TrailingZeroes(int n)
		{
			int fives = 0;

			var limit = 25;
			var count = 1;

			while (n > 0)
			{
				fives += n / 5;
				n = n / 5;
			}

			return fives;
		}

		private int GetZeros(int n, int div)
		{
			int val = 0;
			while (n % div == 0)
			{
				val++;
				n = n / div;
			}
			return val;
		}
	}
}
