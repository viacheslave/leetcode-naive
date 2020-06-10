using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/n-th-tribonacci-number/
	///		Submission: https://leetcode.com/submissions/detail/246919488/
	/// </summary>
	internal class P1137
	{
		public int Tribonacci(int n)
		{
			if (n == 0) return 0;
			if (n == 1 || n == 2) return 1;

			var a1 = 0;
			var a2 = 1;
			var a3 = 1;

			for (int i = 3; i <= n; i++)
			{
				var ne = a3 + a2 + a1;

				a1 = a2;
				a2 = a3;
				a3 = ne;
			}

			return a3;
		}
	}
}
