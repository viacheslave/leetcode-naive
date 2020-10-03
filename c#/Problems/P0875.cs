using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/koko-eating-bananas/
	///		Submission: https://leetcode.com/submissions/detail/403903453/
	/// </summary>
	internal class P0875
	{
		public int MinEatingSpeed(int[] piles, int H)
		{
			var min = 1;
			var max = piles.Max();

			while (max - min > 1)
			{
				var mid = (max + min) / 2;
				var fits = Fits(piles, H, mid);

				if (fits)
					max = mid;
				else
					min = mid;
			}

			var minFits = Fits(piles, H, min);
			//var maxFits = Fits(piles, H, max);

			return minFits ? min : max;
		}

		private bool Fits(int[] piles, int h, int mid)
		{
			var hours = 0;

			foreach (var pile in piles)
			{
				if (pile % mid == 0)
					hours += (pile / mid);
				else
					hours += (pile / mid) + 1;
			}

			return hours <= h;
		}
	}
}
