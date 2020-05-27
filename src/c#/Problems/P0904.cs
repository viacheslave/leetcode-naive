using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/fruit-into-baskets/
	///		Submission: https://leetcode.com/submissions/detail/247539729/
	/// </summary>
	internal class P0904
	{
		public int TotalFruit(int[] tree)
		{
			var hashes = new Dictionary<int, int>();
			var start = 0;
			var max = int.MinValue;

			for (int i = 0; i < tree.Length; i++)
			{
				if (i == 0)
				{
					hashes.Add(tree[0], 0);
					start = 0; max = 1;
					continue;
				}

				if (tree[i] == tree[i - 1]) continue;

				if (hashes.ContainsKey(tree[i]))
				{
					hashes[tree[i]] = i;
					continue;
				}

				if (hashes.Count == 1)
				{
					hashes.Add(tree[i], i);
					continue;
				}

				var first = hashes.OrderBy(h => h.Value).First();
				max = Math.Max(i - start, max);

				hashes.Remove(first.Key);

				start = hashes.Single().Value;
				hashes.Add(tree[i], i);
			}

			return max = Math.Max(tree.Length - start, max);
		}
	}
}
