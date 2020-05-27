using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/largest-values-from-labels/
	///		Submission: https://leetcode.com/submissions/detail/245748982/
	/// </summary>
	internal class P1090
	{
		public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit)
		{
			List<(int, int)> items = new List<(int, int)>();

			for (int i = 0; i < values.Length; i++)
				items.Add((values[i], labels[i]));

			items = items.OrderByDescending(_ => _.Item1).ToList();

			var usedLabels = new SortedDictionary<int, int>();
			var ans = 0;
			var ansCount = 0;

			foreach (var item in items)
			{
				if (CountWithLabel(use_limit, item.Item2, usedLabels))
				{
					ans += item.Item1;
					ansCount++;

					if (ansCount == num_wanted)
						break;

					if (!usedLabels.ContainsKey(item.Item2))
						usedLabels[item.Item2] = 0;

					usedLabels[item.Item2]++;
				}
			}

			return ans;
		}

		private bool CountWithLabel(int limit, int label, SortedDictionary<int, int> usedLabels)
		{
			usedLabels.TryGetValue(label, out var count);
			if (count + 1 <= limit)
				return true;

			return false;
		}
	}
}
