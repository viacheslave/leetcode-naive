using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/length-of-longest-fibonacci-subsequence/
	///		Submission: https://leetcode.com/submissions/detail/243297273/
	/// </summary>
	internal class P0873
	{
		int maxLength = int.MinValue;

		public int LenLongestFibSubseq(int[] A)
		{
			var set = new HashSet<int>(A);

			for (int i = 0; i < A.Length - 2; i++)
			{
				Check(set, A, i);
			}

			return maxLength == 2 ? 0 : maxLength;
		}

		private void Check(HashSet<int> A, int[] original, int first)
		{
			for (int second = first + 1; second < original.Length - 1; second++)
			{
				var list = new List<int>() { original[first], original[second] };
				Rec(list, A);
			}
		}

		private void Rec(List<int> list, HashSet<int> values)
		{
			if (values.Contains(list[list.Count - 1] + list[list.Count - 2]))
			{
				list.Add(list[list.Count - 1] + list[list.Count - 2]);
				Rec(list, values);
			}

			maxLength = Math.Max(maxLength, list.Count);
		}
	}
}
