using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/ugly-number/
	///		Submission: https://leetcode.com/submissions/detail/237776420/
	/// </summary>
	internal class P0263
	{
		public bool IsUgly(int n)
		{
			if (n <= 0)
				return false;

			while (n > 1)
			{
				var div = false;

				if (n % 2 == 0)
				{
					n /= 2;
					div = true;
				}

				if (n % 3 == 0)
				{
					n /= 3;
					div = true;
				}

				if (n % 5 == 0)
				{
					n /= 5;
					div = true;
				}

				if (!div)
					return false;
			}

			return true;
		}
	}
}
