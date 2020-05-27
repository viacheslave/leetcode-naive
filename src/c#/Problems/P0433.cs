using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-genetic-mutation/
	///		Submission: https://leetcode.com/submissions/detail/244086684/
	/// </summary>
	internal class P0433
	{
		public int MinMutation(string start, string end, string[] bank)
		{
			if (bank.Length == 0)
				return -1;

			var bankSet = new HashSet<string>(bank);
			if (!bankSet.Contains(end))
				return -1;

			var visited = new HashSet<string>();

			var queue = new Queue<(string variant, int steps)>();

			queue.Enqueue((end, 0));

			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				if (visited.Contains(item.variant))
					continue;

				visited.Add(item.variant);

				var variants = GetVariants(visited, bankSet, item.variant, start);
				if (variants == null)
					return item.steps + 1;

				foreach (var variant in variants)
					queue.Enqueue((variant, item.steps + 1));
			}

			return -1;
		}

		private List<string> GetVariants(HashSet<string> visited, HashSet<string> bankSet, string variant, string start)
		{
			var sb = new StringBuilder(variant);
			var ch = new List<char> { 'A', 'C', 'G', 'T' };

			var candidates = new HashSet<string>();

			for (int i = 0; i < variant.Length; i++)
			{
				var original = sb[i];

				for (int j = 0; j < ch.Count; j++)
				{
					if (original == ch[j])
						continue;

					sb[i] = ch[j];

					if (sb.ToString() == start)
						return null;

					if (bankSet.Contains(sb.ToString()) && !visited.Contains(sb.ToString()))
						candidates.Add(sb.ToString());
				}

				sb[i] = original;
			}

			return candidates.ToList();
		}
	}
}
