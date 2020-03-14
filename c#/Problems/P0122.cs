using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
	///		Submission: https://leetcode.com/submissions/detail/238582854/
	/// </summary>
	internal class P0122
	{
		public int MaxProfit(int[] prices)
		{
			int minIndex = -1, maxIndex = -1;

			int profit = 0;

			for (var i = 0; i < prices.Length; i++)
			{
				if (minIndex == -1)
				{
					minIndex = i;
					maxIndex = i;
					continue;
				}

				if (maxIndex > minIndex)
				{
					if (prices[i] > prices[maxIndex])
					{
						maxIndex = i;
						continue;
					}
					else
					{
						// sell
						profit += prices[maxIndex] - prices[minIndex];
						minIndex = i;
						maxIndex = i;
					}
				}
				else
				{
					if (prices[i] > prices[minIndex])
					{
						maxIndex = i;
						continue;
					}
					else
					{
						minIndex = i;
						maxIndex = i;
						continue;
					}
				}
			}

			if (maxIndex > minIndex)
				profit += prices[maxIndex] - prices[minIndex];

			return profit;
		}
	}
}
