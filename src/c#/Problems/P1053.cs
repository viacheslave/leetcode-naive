using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/previous-permutation-with-one-swap/
	///		Submission: https://leetcode.com/submissions/detail/245151635/
	/// </summary>
	internal class P1053
	{
		public int[] PrevPermOpt1(int[] A)
		{
			if (A.Length == 0)
				return A;

			for (int i = A.Length - 1; i >= 0; i--)
			{
				if (A[i] == 0)
					continue;

				var minIndex = -1;
				var min = int.MaxValue;

				for (var j = i + 1; j < A.Length; j++)
				{
					if (A[j] < A[i] && A[i] - A[j] < min)
					{
						min = Math.Min(min, A[i] - A[j]);
						minIndex = j;
					}
				}

				if (minIndex != -1)
				{
					var temp = A[minIndex];
					A[minIndex] = A[i];
					A[i] = temp;
					return A;
				}
			}

			return A;
		}
	}
}
