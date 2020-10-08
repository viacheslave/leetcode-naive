using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/stone-game-ii/
	///		Submission: https://leetcode.com/submissions/detail/406064890/
	/// </summary>
	internal class P1140
	{
		public int StoneGameII(int[] piles)
		{
			var suffix = new int[piles.Length];
			for (var i = piles.Length - 1; i >= 0; --i)
			{
				if (i == piles.Length - 1)
					suffix[i] = piles[i];
				else
					suffix[i] = piles[i] + suffix[i + 1];
			}

			var dp = new Dictionary<(int i, int m), int>();

			GetDP(0, 1, dp, piles, suffix);

			return dp
					.Where(k => k.Key.i == 0)
					.Max(x => x.Value);
		}

		private int GetDP(int i, int m, Dictionary<(int i, int m), int> dp, int[] piles, int[] suffix)
		{
			if (dp.ContainsKey((i, m)))
				return dp[(i, m)];

			var maxProfit = 0;

			for (var x = 1; x <= 2 * m; ++x)
			{
				var ii = Math.Min(i + x, piles.Length);

				var otherm = Math.Max(x, m);

				var other = 0;
				if (ii < piles.Length)
					other = GetDP(ii, otherm, dp, piles, suffix);

				var profit = suffix[i] - other;
				maxProfit = Math.Max(maxProfit, profit);
			}

			dp[(i, m)] = maxProfit;
			return maxProfit;
		}
	}
}
