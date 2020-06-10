using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-prefix-divisible-by-5/
	///		Submission: https://leetcode.com/submissions/detail/231273955/
	/// </summary>
	internal class P1018
	{
		public IList<bool> PrefixesDivBy5(int[] A)
		{
			if (A.Length == 0)
				return new List<bool>();

			var res = new List<bool>();
			BigInteger current = 0;
			var i = 0;

			while (i < A.Length)
			{
				current = current * 2 + A[i];
				res.Add(current % 5 == 0);
				i++;
			}

			return res;
		}
	}
}
