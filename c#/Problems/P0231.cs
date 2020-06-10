using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/power-of-two/
	///		Submission: https://leetcode.com/submissions/detail/227350077/
	/// </summary>
	internal class P0231
	{
		public bool IsPowerOfTwo(int n)
		{
			if (n <= 0)
				return false;

			if (n == 1)
				return true;

			while (n > 0)
			{
				if (n % 2 != 0)
					return false;

				n = n / 2;

				if (n == 1)
					return true;
			}

			return true;
		}
	}
}
