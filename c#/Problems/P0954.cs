using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/array-of-doubled-pairs/
	///		Submission: https://leetcode.com/submissions/detail/240965429/
	/// </summary>
	internal class P0954
	{
		public bool CanReorderDoubled(int[] A)
		{
			var sorted = new SortedDictionary<int, int>(A.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count()));

			while (sorted.Count > 0)
			{
				var min = sorted.Keys.Min();

				sorted[min]--;
				if (sorted[min] == 0) sorted.Remove(min);

				var expected = (min == 0) ? 0 : (min < 0 ? (min / 2) : (min * 2));

				if (sorted.TryGetValue(expected, out var value))
				{
					sorted[expected]--;
					if (sorted[expected] == 0) sorted.Remove(expected);
					continue;
				}

				return false;
			}

			return true;
		}
	}
}
