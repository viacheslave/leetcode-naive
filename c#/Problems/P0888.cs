using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/fair-candy-swap/
	///		Submission: https://leetcode.com/submissions/detail/246498642/
	/// </summary>
	internal class P0888
	{
		public int[] FairCandySwap(int[] A, int[] B)
		{
			var asum = A.Sum();
			var bsum = B.Sum();
			var avg = (asum + bsum) / 2;

			var diffswap = Math.Abs(asum - avg);

			var sign = asum < bsum ? 1 : -1;

			var arrLessSet = new HashSet<int>();
			for (int i = 0; i < A.Length; i++)
				arrLessSet.Add(A[i]);

			var arrGreaterSet = new HashSet<int>();
			for (int i = 0; i < B.Length; i++)
				arrGreaterSet.Add(B[i]);

			foreach (var item in arrLessSet)
			{
				if (arrGreaterSet.Contains(item + sign * diffswap))
					return new int[] { item, item + sign * diffswap };
			}

			return null;
		}
	}
}
