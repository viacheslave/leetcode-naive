using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/perfect-squares/
	///		Submission: https://leetcode.com/submissions/detail/237771775/
	/// </summary>
	internal class P0279
	{
		public int NumSquares(int n)
		{
			var map = new Dictionary<int, int>();
			map[0] = 0;

			var maxsqindex = GetMaxSqIndex(n);

			for (var i = 1; i <= n; i++)
			{
				var min = int.MaxValue;
				for (var j = 0; j < maxsqindex; j++)
				{
					var c = GetSq(j + 1);

					if (i - c >= 0)
					{
						var mapValue = map[i - c];
						if (mapValue != int.MaxValue)
						{
							min = Math.Min(min, mapValue + 1);
						}
					}
				}

				map[i] = min;
			}

			return map[n] == int.MaxValue ? -1 : map[n];
		}

		int GetSq(int j) => j * j;

		int GetMaxSqIndex(int n)
		{
			var index = 1;
			while ((index + 1) * (index + 1) <= n)
				index++;

			return index;
		}
	}
}
