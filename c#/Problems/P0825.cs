using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/friends-of-appropriate-ages
	///		Submission: https://leetcode.com/submissions/detail/241206759/
	/// </summary>
	internal class P0825
	{
		public int NumFriendRequests(int[] ages)
		{
			var count = 0;
			var hs = new double[ages.Length];

			Array.Sort(ages);

			for (var i = 0; i < ages.Length; i++)
				hs[i] = ages[i] * 0.5 + 7;

			int a;
			int right = -1;

			for (int b = 0; b < ages.Length; b++)
			{
				if (right > b)
				{
					a = right;
					count += (right - b - 1);
				}
				else
				{
					a = b + 1;
				}

				while (a < ages.Length && ages[b] > hs[a])
				{
					count++;
					a++;
				}

				right = a;

				a = b - 1;
				while (a >= 0 && ages[b] <= ages[a] && ages[b] > hs[a])
				{
					count++;
					a--;
				}
			}

			return count;
		}
	}
}
