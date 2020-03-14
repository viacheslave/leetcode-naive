using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/k-th-symbol-in-grammar/
	///		Submission: https://leetcode.com/submissions/detail/243519175/
	/// </summary>
	internal class P0779
	{
		public int KthGrammar(int N, int K)
		{
			if (N == 1)
				return 0;

			var prevIndex = (K % 2 == 1)
					? (K + 1) / 2
					: K / 2;

			var value = KthGrammar(N - 1, prevIndex);

			int i1 = prevIndex * 2 - 1;
			int v1;
			int v2;

			if (value == 0)
			{
				v1 = 0;
				v2 = 1;
			}
			else
			{
				v1 = 1;
				v2 = 0;
			}

			if (K == i1) return v1;
			else return v2;
		}
	}
}
