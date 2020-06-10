using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-sum-of-two-non-overlapping-subarrays/
	///		Submission: https://leetcode.com/submissions/detail/239541594/
	/// </summary>
	internal class P1031
	{
		public int MaxSumTwoNoOverlap(int[] A, int L, int M)
		{
			var prefixSums = new int[A.Length];

			for (var i = 0; i < A.Length; i++)
				prefixSums[i] += A[i] + (i == 0 ? 0 : prefixSums[i - 1]);

			var maxSum = int.MinValue;

			for (var i = 0; i < A.Length - L + 1; i++)
			{
				var sumL = prefixSums[i + L - 1] - (i == 0 ? 0 : prefixSums[i - 1]);

				for (var j = 0; j < i - M + 1; j++)
				{
					var sumM = prefixSums[j + M - 1] - (j == 0 ? 0 : prefixSums[j - 1]);
					maxSum = Math.Max(maxSum, sumL + sumM);
				}

				for (var j = i + L; j < A.Length - M + 1; j++)
				{
					var sumM = prefixSums[j + M - 1] - (j == 0 ? 0 : prefixSums[j - 1]);
					maxSum = Math.Max(maxSum, sumL + sumM);
				}
			}

			return maxSum;
		}
	}
}
