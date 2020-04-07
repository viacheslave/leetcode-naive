using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-lucky-integer-in-an-array/
	///		Submission: https://leetcode.com/submissions/detail/321246653/
	/// </summary>
	internal class P1394
	{
		public int FindLucky(int[] arr)
		{
			var items = arr
				.GroupBy(x => x)
				.Where(x => x.Key == x.Count())
				.OrderBy(x => x.Key)
				.Select(x => x.Key)
				.ToList();
			return items.Count > 0
				? items.Last()
				: -1;
		}
	}
}
