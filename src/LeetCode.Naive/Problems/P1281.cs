using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
	///		Submission: https://leetcode.com/submissions/detail/284798553/
	/// </summary>
	internal class P1281
	{
		public int SubtractProductAndSum(int n)
		{
			var digits = n.ToString()
				.Select(_ => int.Parse(_.ToString()))
				.ToList();

			return digits.Aggregate((a, b) => a * b) - digits.Sum();
		}
	}
}
