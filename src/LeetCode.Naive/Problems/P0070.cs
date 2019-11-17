using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/climbing-stairs/
	///		Submission: https://leetcode.com/submissions/detail/226898975/
	/// </summary>
	internal class P0070
	{
		Dictionary<int, int> fib = new Dictionary<int, int>()
		{
				{1, 1},
				{2, 2},
				{3, 3}
		};

		public int ClimbStairs(int n)
		{

			for (var i = 4; i <= n; i++)
			{
				fib[i] = fib[i - 1] + fib[i - 2];
			}


			return fib[n];
		}
	}
}
