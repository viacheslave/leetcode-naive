using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/squares-of-a-sorted-array/
	///		Submission: https://leetcode.com/submissions/detail/227847201/
	/// </summary>
	internal class P0977
	{
		public int[] SortedSquares(int[] A)
		{
			if (A.Length == 0)
				return A;

			if (A.Length == 1)
				return new int[] { A[0] * A[0] };

			var result = new int[A.Length];

			int index = A.Length - 1;

			int left = 0;
			int right = A.Length - 1;

			while (left <= right)
			{
				if (left == right)
				{
					result[index] = A[left] * A[left];
					left++;
					continue;
				}

				if (A[left] * A[left] == A[right] * A[right])
				{
					result[index] = A[left] * A[left];
					result[index - 1] = A[right] * A[right];
					index = index - 2;
					left++;
					right--;
					continue;
				}

				if (A[left] * A[left] < A[right] * A[right])
				{
					// insert right
					result[index] = A[right] * A[right];
					index--;
					right--;
					continue;
				}

				if (A[left] * A[left] > A[right] * A[right])
				{
					// insert left
					result[index] = A[left] * A[left];
					index--;
					left++;
					continue;
				}
			}

			return result;
		}
	}
}
