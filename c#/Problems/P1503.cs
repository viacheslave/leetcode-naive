using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/last-moment-before-all-ants-fall-out-of-a-plank/
	///		Submission: https://leetcode.com/submissions/detail/390968874/
	/// </summary>
	internal class P1503
	{
		public int GetLastMoment(int n, int[] left, int[] right)
		{
			return Math.Max(
					left.Length > 0 ? left.Max() : 0,
					right.Length > 0 ? n - right.Min() : 0);
		}
	}
}
