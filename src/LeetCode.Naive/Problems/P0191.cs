using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-1-bits/
	///		Submission: https://leetcode.com/submissions/detail/227854276/
	/// </summary>
	internal class P0191
	{
		public int HammingWeight(uint n)
		{
			var i = 32;

			int res = 0;
			while (i-- > 0)
			{
				if ((n % 2) == 1)
					res++;

				n = n >> 1;
			}


			return res;
		}
	}
}
