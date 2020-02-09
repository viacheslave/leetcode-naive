using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sort-array-by-parity-ii/
	///		Submission: https://leetcode.com/submissions/detail/233824429/
	/// </summary>
	internal class P0922
	{
		public int[] SortArrayByParityII(int[] A)
		{
			for (var i = 0; i < A.Length; i++)
			{
				if (i % 2 == 0 && A[i] % 2 != 0)
				{
					var nexteven = GetNext(A, i + 1, true);
					Swap(A, i, nexteven);
				}

				if (i % 2 == 1 && A[i] % 2 != 1)
				{
					var nextodd = GetNext(A, i + 1, false);
					Swap(A, i, nextodd);
				}
			}

			return A;
		}

		private int GetNext(int[] A, int start, bool even)
		{
			while (start < A.Length)
			{
				if (even && A[start] % 2 == 0)
					return start;

				if (!even && A[start] % 2 == 1)
					return start;

				start++;
			}
			return -1;
		}

		private void Swap(int[] A, int i1, int i2)
		{
			var tmp = A[i1];
			A[i1] = A[i2];
			A[i2] = tmp;
		}
	}
}
