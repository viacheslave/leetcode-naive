using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shortest-distance-to-a-character/
	///		Submission: https://leetcode.com/submissions/detail/230931067/
	/// </summary>
	internal class P0821
	{
		public int[] ShortestToChar(string S, char C)
		{
			var exact = new List<int>();

			for (var i = 0; i < S.Length; i++)
			{
				if (C == S[i])
					exact.Add(i);
			}

			var res = new int[S.Length];
			var pass = -1;

			for (var i = 0; i < S.Length; i++)
			{
				if (i < exact[0])
				{
					res[i] = Math.Abs(i - exact[0]);
					continue;
				}

				if (i > exact[exact.Count - 1])
				{
					res[i] = Math.Abs(i - exact[exact.Count - 1]);
					continue;
				}

				if (S[i] == C)
				{
					pass++;
					res[i] = 0;
					continue;
				}

				res[i] = Math.Min(
						Math.Abs(i - exact[pass]),
						Math.Abs(exact[pass + 1] - i));
			}

			return res;
		}
	}
}
