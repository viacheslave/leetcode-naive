using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/gas-station/
	///		Submission: https://leetcode.com/submissions/detail/245910052/
	/// </summary>
	internal class P0134
	{
		public int CanCompleteCircuit(int[] gas, int[] cost)
		{
			if (gas.Sum() < cost.Sum())
				return -1;

			for (var start = 0; start < gas.Length; start++)
			{
				var counter = 0;
				var currentPos = start + counter;
				var accum = 0;
				var possible = true;

				while (counter < gas.Length)
				{
					accum += gas[currentPos % gas.Length] - cost[currentPos % gas.Length];
					if (accum < 0)
					{
						possible = false;
						break;
					}

					counter++;
					currentPos = start + counter;
				}

				if (possible)
					return start;
			}

			return -1;
		}
	}
}
