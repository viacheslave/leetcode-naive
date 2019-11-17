using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/combinations/
	///		Submission: https://leetcode.com/submissions/detail/231551149/
	/// </summary>
	internal class P0077
	{
		public IList<IList<int>> Combine(int n, int k)
		{
			int[] filled = new int[k];
			for (var i = 0; i < k; i++)
				filled[i] = -1;

			IList<IList<int>> res = new List<IList<int>>();

			Rec(res, filled, n, k, 0, 1);

			return res;
		}

		private void Rec(IList<IList<int>> res, int[] filled, int n, int k, int digit, int start)
		{
			if (digit == k)
			{
				var cand = new List<int>();
				for (var i = 0; i < filled.Length; i++)
					cand.Add(filled[i]);

				res.Add(cand);
				return;
			}

			for (var i = start; i <= n; i++)
			{
				filled[digit] = i;

				Rec(res, filled, n, k, digit + 1, i + 1);
			}
		}
	}
}
