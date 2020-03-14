using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sort-array-by-parity/
	///		Submission: https://leetcode.com/submissions/detail/230916683/
	/// </summary>
	internal class P0905
	{
		public int[] SortArrayByParity(int[] A)
		{
			return A.Where(_ => _ % 2 == 0).Concat(
					A.Where(_ => _ % 2 == 1))
					.ToArray();
		}
	}
}
