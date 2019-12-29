using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/
	///		Submission: https://leetcode.com/submissions/detail/289433999/
	/// </summary>
	internal class P5295
	{
		public int[] SumZero(int n)
		{
			if (n == 1)
				return new int[] { 0 };
			if (n == 2)
				return new int[] { 1, -1 };

			var en = Enumerable.Range(0, n - 1).ToList();
			en.Add((-1) * en.Sum());

			return en.ToArray();
		}
	}
}
