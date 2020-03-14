using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/arranging-coins/
	///		Submission: https://leetcode.com/submissions/detail/229577818/
	/// </summary>
	internal class P0441
	{
		public int ArrangeCoins(int n)
		{
			var value = (-1 + Math.Sqrt(1L + 8L * n)) / 2;
			return (int)Math.Floor(value);
		}
	}
}
