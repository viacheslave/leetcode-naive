using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/coin-change-2/
	///		Submission: https://leetcode.com/submissions/detail/244863122/
	/// </summary>
	internal class P0518
	{
		public int Change(int amount, int[] coins)
		{
			if (amount == 0) return 1;

			Array.Sort(coins);
			var map = new Dictionary<(int, int), int>();

			var variants = 0;

			for (int c = coins.Length - 1; c >= 0; c--)
				variants += GetVariants(amount, coins[c], coins, map);

			return variants;
		}

		private int GetVariants(int amount, int highCoin, int[] coins, Dictionary<(int, int), int> map)
		{
			if (amount <= 0)
				return 0;

			if (amount == highCoin)
				return 1;

			var variants = 0;
			for (int c = coins.Length - 1; c >= 0; c--)
			{
				if (coins[c] > highCoin)
					continue;

				if (!map.TryGetValue((amount - highCoin, coins[c]), out var value))
				{
					value = GetVariants(amount - highCoin, coins[c], coins, map);
					map[(amount - highCoin, coins[c])] = value;
				}

				variants += value;
			}

			return variants;
		}
	}
}
