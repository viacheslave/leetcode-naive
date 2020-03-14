using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers/
	///		Submission: https://leetcode.com/submissions/detail/293560329/
	/// </summary>
	internal class P1317
	{
		public int[] GetNoZeroIntegers(int n)
		{
			for (var i = 1; i < n; i++)
			{
				if (i.ToString().All(x => x != '0') && (n - i).ToString().All(x => x != '0'))
					return new int[] { i, n - i };
			}

			return null;
		}
	}
}
