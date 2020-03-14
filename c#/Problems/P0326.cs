using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/power-of-three/
	///		Submission: https://leetcode.com/submissions/detail/227350284/
	/// </summary>
	internal class P0326
	{
		public bool IsPowerOfThree(int n)
		{
			if (n <= 0)
				return false;

			if (n == 1)
				return true;

			while (n > 0)
			{
				if (n % 3 != 0)
					return false;

				n = n / 3;

				if (n == 1)
					return true;
			}

			return true;
		}
	}
}
