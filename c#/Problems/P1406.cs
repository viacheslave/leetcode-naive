using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/stone-game-iii/
	///		Submission: https://leetcode.com/submissions/detail/406123808/
	/// </summary>
	internal class P1406
	{
		public string StoneGameIII(int[] stoneValue)
		{
			var suffix = new int[stoneValue.Length];
			for (var i = stoneValue.Length - 1; i >= 0; --i)
			{
				if (i == stoneValue.Length - 1)
					suffix[i] = stoneValue[i];
				else
					suffix[i] = stoneValue[i] + suffix[i + 1];
			}

			var dp = new Dictionary<int, int>();

			var alice = GetDP(0, dp, stoneValue, suffix);
			var bob = stoneValue.Sum() - alice;

			if (alice == bob)
				return "Tie";
			return alice < bob ? "Bob" : "Alice";
		}

		private int GetDP(int pos, Dictionary<int, int> dp, int[] stoneValue, int[] suffix)
		{
			if (dp.ContainsKey(pos))
				return dp[pos];

			if (pos >= stoneValue.Length)
				return 0;

			var maxProfit = int.MinValue;

			for (var x = 1; x <= 3; ++x)
			{
				var profit = suffix[pos] - GetDP(pos + x, dp, stoneValue, suffix);
				maxProfit = Math.Max(maxProfit, profit);
			}

			dp[pos] = maxProfit;
			return maxProfit;
		}
	}
}
