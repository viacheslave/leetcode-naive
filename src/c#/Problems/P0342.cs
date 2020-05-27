using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/power-of-four/
	///		Submission: https://leetcode.com/submissions/detail/227350351/
	/// </summary>
	internal class P0342
	{
		public bool IsPowerOfFour(int n)
		{
			if (n <= 0)
				return false;

			if (n == 1)
				return true;

			while (n > 0)
			{
				if (n % 4 != 0)
					return false;

				n = n / 4;

				if (n == 1)
					return true;
			}

			return true;
		}
	}
}
