using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/last-stone-weight/
	///		Submission: https://leetcode.com/submissions/detail/233644687/
	/// </summary>
	internal class P1046
	{
		public int LastStoneWeight(int[] stones)
		{
			var list = stones.ToList();

			while (list.Count > 1)
			{
				list.Sort();

				if (list[list.Count - 1] == list[list.Count - 2])
				{
					list.RemoveRange(list.Count - 2, 2);
					continue;
				}

				var diff = Math.Abs(list[list.Count - 1] - list[list.Count - 2]);
				list.RemoveRange(list.Count - 2, 2);
				list.Add(diff);
			}

			return list.Count == 0 ? 0 : list.First();
		}
	}
}
