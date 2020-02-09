using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array/
	///		Submission: https://leetcode.com/submissions/detail/286080836/
	/// </summary>
	internal class P1287
	{
		public int FindSpecialInteger(int[] arr)
		{
			var thres = arr.Length / 4;

			return arr.GroupBy(x => x)
					.ToDictionary(x => x.Key, x => x.Count())
					.Single(x => x.Value > thres)
					.Key;
		}
	}
}
