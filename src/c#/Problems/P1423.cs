using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/
	///		Submission: https://leetcode.com/submissions/detail/331989931/
	/// </summary>
	internal class P1423
	{
		public int MaxScore(int[] cardPoints, int k)
		{
			var windowLength = cardPoints.Length - k;
			var sum = cardPoints.Sum();

			var currentSum = cardPoints.Take(windowLength).Sum();
			var ans = currentSum;

			// min
			for (var start = 1; start <= cardPoints.Length - windowLength; start++)
			{
				currentSum = currentSum - cardPoints[start - 1] + cardPoints[start + windowLength - 1];
				ans = Math.Min(ans, currentSum);
			}

			return sum - ans;
		}
	}
}
