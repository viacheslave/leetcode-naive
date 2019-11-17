using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/
	///		Submission: https://leetcode.com/submissions/detail/227163659/
	/// </summary>
	internal class P0914
	{
		public bool HasGroupsSizeX(int[] deck)
		{
			if (deck.Length <= 1)
				return false;

			var map = new Dictionary<int, int>();

			for (int i = 0; i < deck.Length; i++)
			{
				if (!map.ContainsKey(deck[i]))
					map[deck[i]] = 0;

				map[deck[i]]++;
			}

			var minCount = 0;
			var maxCount = 0;

			foreach (var item in map)
			{
				//if (minCount == 0)
				//    minCount = item.Value;

				if (maxCount == 0)
					maxCount = item.Value;

				//if (minCount != 0 && item.Value < minCount)
				//    minCount = item.Value;

				if (maxCount != 0 && item.Value > maxCount)
					maxCount = item.Value;
			}


			for (var size = 2; size <= maxCount; size++)
			{
				var can = true;

				foreach (var item in map)
				{
					can = can && (item.Value % size == 0);
				}

				if (can)
					return true;
			}

			return false;
		}
	}
}
