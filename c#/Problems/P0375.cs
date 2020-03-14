using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/guess-number-higher-or-lower-ii/
	///		Submission: https://leetcode.com/submissions/detail/234944457/
	/// </summary>
	internal class P0375
	{
		public int GetMoneyAmount(int n)
		{
			int start = 1, end = n;
			var map = new Dictionary<(int, int), int>();

			return Get(start, end, map);
		}

		public int Get(int start, int end, Dictionary<(int, int), int> map)
		{
			if (end - start == 1)
				return start;

			if (end - start == 0)
				return 0;

			if (map.ContainsKey((start, end)))
				return map[(start, end)];

			var min = int.MaxValue;
			for (var middle = start + 1; middle < end; middle++)
			{
				var left = Get(start, middle - 1, map);
				var right = Get(middle + 1, end, map);

				min = Math.Min(min, middle + Math.Max(left, right));
			}

			map[(start, end)] = min;
			return min;
		}
	}
}
