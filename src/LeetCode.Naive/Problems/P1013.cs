using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/partition-array-into-three-parts-with-equal-sum/
	///		Submission: https://leetcode.com/submissions/detail/238515200/
	/// </summary>
	internal class P1013
	{
		public bool CanThreePartsEqualSum(int[] A)
		{
			if (A.Length == 0)
				return false;

			var sum = A.Sum();
			if (sum % 3 != 0)
				return false;

			sum /= 3;

			var lastIndex = -1;

			var value = 0;
			var found = false;
			for (var i = 0; i < A.Length; i++)
			{
				value += A[i];
				if (value == sum)
				{
					lastIndex = i;
					found = true;
					break;
				}
			}

			if (!found || lastIndex > A.Length - 2)
				return false;

			value = 0;
			found = false;
			for (var i = lastIndex + 1; i < A.Length; i++)
			{
				value += A[i];
				if (value == sum)
				{
					lastIndex = i;
					found = true;
					break;
				}
			}

			if (!found || lastIndex > A.Length - 1)
				return false;

			value = 0;
			found = false;
			for (var i = lastIndex + 1; i < A.Length; i++)
			{
				value += A[i];
				if (value == sum)
				{
					found = true;
					break;
				}
			}

			if (!found)
				return false;

			return true;
		}
	}
}
