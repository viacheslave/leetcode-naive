using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/peak-index-in-a-mountain-array/
	///		Submission: https://leetcode.com/submissions/detail/234339958/
	/// </summary>
	internal class P0852
	{
		public int PeakIndexInMountainArray(int[] A)
		{
			return Array.IndexOf(A, A.Max());
		}
	}
}
