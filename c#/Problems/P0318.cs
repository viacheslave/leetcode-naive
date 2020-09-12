using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-product-of-word-lengths/
	///		Submission: https://leetcode.com/submissions/detail/394667554/
	/// </summary>
	internal class P0318
	{
		public int MaxProduct(string[] words)
		{
			var map = new Dictionary<string, int>();
			foreach (var word in words)
			{
				var value = 0;
				foreach (var ch in word.Distinct().ToHashSet())
					value += (int)Math.Pow(2, ch - 97);

				map[word] = value;
			}

			var values = map.ToList();
			var max = 0;

			for (var i = 0; i < values.Count; i++)
				for (var j = 1; j < values.Count; j++)
					if ((values[i].Value & values[j].Value) == 0)
						max = Math.Max(max, values[i].Key.Length * values[j].Key.Length);

			return max;
		}
	}
}
