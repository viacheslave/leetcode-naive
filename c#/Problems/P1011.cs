using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/
	///		Submission: https://leetcode.com/submissions/detail/250286355/
	/// </summary>
	internal class P1011
	{
		public int ShipWithinDays(int[] weights, int D)
		{
			var initialCapacity = (int)Math.Floor(1.0 * (weights.Sum() / D));

			if (IsPossible(weights, D, initialCapacity))
				return initialCapacity;

			var left = initialCapacity;
			var right = initialCapacity;

			while (!IsPossible(weights, D, right))
				right += initialCapacity;

			while (true)
			{
				if (right - left == 1)
					return right;

				var middle = (right + left) / 2;
				var possble = IsPossible(weights, D, middle);

				if (possble)
				{
					right = middle;
				}
				else
				{
					left = middle;
				}
			}

			return right;
		}

		private bool IsPossible(int[] weights, int days, int test)
		{
			var sum = 0;
			var day = 1;

			for (int i = 0; i < weights.Length; i++)
			{
				if (weights[i] > test)
					return false;

				if (sum + weights[i] <= test)
					sum += weights[i];
				else
				{
					sum = weights[i];
					day++;

					if (day > days)
						return false;
				}
			}

			return true;
		}
	}
}
