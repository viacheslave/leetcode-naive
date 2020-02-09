using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/n-repeated-element-in-size-2n-array/
	///		Submission: https://leetcode.com/submissions/detail/234322729/
	/// </summary>
	internal class P0961
	{
		public int RepeatedNTimes(int[] A)
		{
			var h = new HashSet<int>();

			foreach (var e in A)
			{
				if (h.Contains(e))
					return e;

				h.Add(e);
			}

			return -1;
		}
	}
}
