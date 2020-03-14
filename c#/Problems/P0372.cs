using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/super-pow/
	///		Submission: https://leetcode.com/submissions/detail/242477020/
	/// </summary>
	internal class P0372
	{
		public int SuperPow(int a, int[] b)
		{
			var result = 1;
			var bas = a;

			for (int i = b.Length - 1; i >= 0; i--)
			{
				result = (result * Pow(bas, b[i])) % 1337;
				bas = Pow(bas, 10);
			}

			return result;
		}

		private int Pow(int bas, int power)
		{
			var result = 1;
			for (int i = 0; i < power; i++)
				result = ((result % 1337) * (bas % 1337)) % 1337;

			return result;
		}
	}
}
