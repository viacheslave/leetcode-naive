using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/h-index-ii/
	///		Submission: https://leetcode.com/submissions/detail/244422192/
	/// </summary>
	internal class P0275
	{
		public int HIndex(int[] citations)
		{
			var i = 0;
			var j = citations.Length - 1;

			while (i <= j)
			{
				if (j - i <= 1)
				{
					if (citations.Length - i <= citations[i])
						return citations.Length - i;
					if (citations.Length - j <= citations[j])
						return citations.Length - j;
					return 0;
				}

				var mid = (j + i) / 2;
				if (citations.Length - mid == citations[mid])
					return citations.Length - mid;

				if (citations.Length - mid < citations[mid])
					j = mid;
				else
					i = mid;
			}

			return 0;
		}
	}
}
