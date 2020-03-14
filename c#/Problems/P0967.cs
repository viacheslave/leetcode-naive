using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/numbers-with-same-consecutive-differences/
	///		Submission: https://leetcode.com/submissions/detail/244867427/
	/// </summary>
	internal class P0967
	{
		public int[] NumsSameConsecDiff(int N, int K)
		{
			var list = new List<int>();
			var res = new HashSet<int>();

			for (int i = (N == 1) ? 0 : 1; i < 10; i++)
			{
				list.Add(i);
				Traverse(res, list, K, N, i);
				list.Remove(i);
			}

			return res.ToArray();
		}

		private void Traverse(HashSet<int> res, List<int> list, int K, int N, int current)
		{
			if (list.Count == N)
			{
				res.Add(int.Parse(string.Join("", list)));
				return;
			}

			if (current - K >= 0)
			{
				list.Add(current - K);
				Traverse(res, list, K, N, current - K);
				list.RemoveAt(list.Count - 1);
			}

			if (current + K < 10)
			{
				list.Add(current + K);
				Traverse(res, list, K, N, current + K);
				list.RemoveAt(list.Count - 1);
			}
		}
	}
}
