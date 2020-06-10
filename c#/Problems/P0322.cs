using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/coin-change/
	///		Submission: https://leetcode.com/submissions/detail/235253064/
	/// </summary>
	internal class P0322
	{
		public int CoinChange(int[] coins, int amount)
		{
			var map = new Dictionary<int, int>();
			map[0] = 0;

			for (var i = 1; i <= amount; i++)
			{
				var min = int.MaxValue;
				for (var j = 0; j < coins.Length; j++)
				{
					if (i - coins[j] >= 0)
					{
						var mapValue = map[i - coins[j]];
						if (mapValue != int.MaxValue)
						{
							min = Math.Min(min, mapValue + 1);
						}
					}
				}

				map[i] = min;
			}

			return map[amount] == int.MaxValue ? -1 : map[amount];
		}
	}
}
