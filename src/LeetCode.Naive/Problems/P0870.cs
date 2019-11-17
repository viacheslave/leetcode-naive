using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/advantage-shuffle/
	///		Submission: https://leetcode.com/submissions/detail/230689218/
	/// </summary>
	internal class P0870
	{
		public int[] AdvantageCount(int[] A, int[] B)
		{

			var res = new int[B.Length];

			Array.Sort(A);

			var taken = new HashSet<int>();

			for (var i = 0; i < B.Length; i++)
			{
				var current = B[i];

				var took = false;
				for (var j = 0; j < A.Length; j++)
				{
					if (A[j] > B[i] && !taken.Contains(j))
					{
						res[i] = A[j];
						taken.Add(j);
						took = true;
						A[j] = -1;
						break;
					}
				}

				if (!took)
					res[i] = -1;
			}

			var left = A.Where(el => el != -1).ToArray();

			var aindex = 0;
			for (var i = 0; i < res.Length; i++)
			{
				if (res[i] == -1)
				{
					res[i] = left[aindex];
					aindex++;
				}
			}

			return res;
		}
	}
}
