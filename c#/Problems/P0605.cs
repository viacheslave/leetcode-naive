using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/can-place-flowers/
	///		Submission: https://leetcode.com/submissions/detail/231120465/
	/// </summary>
	internal class P0605
	{
		public bool CanPlaceFlowers(int[] flowerbed, int n)
		{
			var prev = -2;
			var count = 0;

			for (var i = 0; i < flowerbed.Length; i++)
			{
				if (flowerbed[i] == 0)
					continue;

				if (i - prev >= 4)
				{
					count += ((i - prev) - 2) / 2;
				}

				prev = i;
			}

			if (flowerbed.Length + 1 - prev >= 4)
			{
				count += ((flowerbed.Length + 1 - prev) - 2) / 2;
			}

			return n <= count;
		}
	}
}
