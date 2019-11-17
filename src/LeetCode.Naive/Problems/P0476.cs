using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-complement/
	///		Submission: https://leetcode.com/submissions/detail/230434120/
	/// </summary>
	internal class P0476
	{
		public int FindComplement(int num)
		{
			if (num == 1)
				return 0;

			var power = 0;
			while (num > (int)Math.Pow(2, power))
			{
				power++;
				if (power == 31)
					break;
			}

			var res = 0;

			for (var i = 0; i < power; i++)
			{
				var digit = (num % 2) ^ 1;
				num = num >> 1;

				res += digit == 1 ? (int)Math.Pow(2, i) : 0;
			}

			return res;
		}
	}
}
