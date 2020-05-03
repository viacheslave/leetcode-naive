using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away/
	///		Submission: https://leetcode.com/submissions/detail/333722520/
	/// </summary>
	internal class P1437
	{
		public bool KLengthApart(int[] nums, int k)
		{
			var ones = nums
				.Select((n, i) => (i, n))
				.Where(n => n.n == 1)
				.Select(n => n.i)
				.ToList();

			if (ones.Count <= 1)
				return true;

			var dist = new int[ones.Count - 1];

			for (int i = 0; i < ones.Count - 1; i++)
				dist[i] = ones[i + 1] - ones[i] - 1;

			return dist.All(n => n >= k);
		}
	}
}
