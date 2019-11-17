using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/heaters/
	///		Submission: https://leetcode.com/submissions/detail/238036378/
	/// </summary>
	internal class P0475
	{
		public int FindRadius(int[] houses, int[] heaters)
		{
			Array.Sort(houses);

			Array.Sort(heaters);

			var he = 0;
			var ho = 0;

			var minHeaterRadius = 0;

			while (ho < houses.Length)
			{
				if (heaters[he] >= houses[ho])
				{
					minHeaterRadius = Math.Max(Math.Abs(heaters[he] - houses[ho]), minHeaterRadius);
					ho++;
					continue;
				}

				var closestHeater = GetClosestHeater(ho, he, heaters, houses);
				minHeaterRadius = Math.Max(Math.Abs(heaters[closestHeater] - houses[ho]), minHeaterRadius);

				he = closestHeater;
				ho++;
			}

			return minHeaterRadius;
		}

		private int GetClosestHeater(int ho, int he, int[] heaters, int[] houses)
		{
			var min = Math.Abs(houses[ho] - heaters[he]);

			while (he + 1 < heaters.Length)
			{
				var next = Math.Abs(heaters[he + 1] - houses[ho]);
				if (next > min)
					return he;

				min = next;
				he++;
			}

			return he;
		}
	}
}
