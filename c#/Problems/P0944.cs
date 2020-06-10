using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/delete-columns-to-make-sorted/
	///		Submission: https://leetcode.com/submissions/detail/246489981/
	/// </summary>
	internal class P0944
	{
		public int MinDeletionSize(string[] A)
		{
			if (A.Length <= 1)
				return 0;

			var ans = 0;
			var wordLength = A[0].Length;

			for (int chPos = 0; chPos < wordLength; chPos++)
			{
				for (int wordIndex = 1; wordIndex < A.Length; wordIndex++)
				{
					if (A[wordIndex][chPos] < A[wordIndex - 1][chPos])
					{
						ans++;
						break;
					}
				}
			}

			return ans;
		}
	}
}
