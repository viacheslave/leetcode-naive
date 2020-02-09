using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/2-keys-keyboard/
	///		Submission: https://leetcode.com/submissions/detail/237122288/
	/// </summary>
	internal class P0650
	{
		public int MinSteps(int n)
		{
			var sum = 0;

			while (n > 1)
			{
				var div = GetMinDivisor(n);
				if (div == -1)
				{
					sum += n;
					break;
				}

				sum += div;
				n = n / div;
			}

			return sum;
		}

		public int GetMinDivisor(int n)
		{
			for (var i = 2; i <= Math.Sqrt(n); i++)
			{
				if (n % i == 0)
					return i;
			}

			return -1;
		}
	}
}
