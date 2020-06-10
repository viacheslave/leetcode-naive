using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-and-replace-in-string/
	///		Submission: https://leetcode.com/submissions/detail/250278894/
	/// </summary>
	internal class P0833
	{
		public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
		{
			var map = new SortedDictionary<int, (string, string)>();
			for (int i = 0; i < indexes.Length; i++)
			{
				map[indexes[i]] = (sources[i], targets[i]);
			}

			var sb = new StringBuilder(S);

			var inc = 0;

			foreach (var mapItem in map)
			{
				var index = mapItem.Key + inc;
				var source = mapItem.Value.Item1;
				var target = mapItem.Value.Item2;

				var str = sb.ToString();
				if (str.Substring(index, source.Length) == source)
				{
					sb.Remove(index, source.Length);
					sb.Insert(index, target);

					inc += (target.Length - source.Length);
				}
			}

			return sb.ToString();
		}
	}
}
