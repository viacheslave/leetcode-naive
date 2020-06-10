using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/h-index/
	///		Submission: https://leetcode.com/submissions/detail/237356519/
	/// </summary>
	internal class P0274
	{
		public int HIndex(int[] citations)
		{
			if (citations.Length == 0)
				return 0;

			Array.Sort(citations);

			for (var i = citations.Length - 1; i >= 0; i--)
			{
				var leftIndex = i == 0 ? 0 : citations[i - 1];
				var rightIndex = Math.Min(citations.Length - i, citations[i]);

				if (leftIndex > rightIndex)
					continue;

				return rightIndex;
			}

			return 1;
		}
	}
}
