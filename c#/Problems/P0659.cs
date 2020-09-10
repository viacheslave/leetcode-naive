using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/split-array-into-consecutive-subsequences/
	///		Submission: https://leetcode.com/submissions/detail/388079621/
	/// </summary>
	internal class P0659
	{
		public bool IsPossible(int[] nums)
		{
			var coll = new Dictionary<int, List<int>>();

			foreach (var num in nums)
			{
				var prev = num - 1;

				if (!coll.ContainsKey(prev))
				{
					if (!coll.ContainsKey(num))
						coll[num] = new List<int>();

					coll[num].Add(1);
					continue;
				}

				var bucket = coll[prev];
				var min = bucket.Min();

				bucket.Remove(min);
				if (bucket.Count == 0)
					coll.Remove(prev);

				if (!coll.ContainsKey(num))
					coll.Add(num, new List<int>());

				coll[num].Add(min + 1);
			}

			return coll.Count > 0 && coll.Values.SelectMany(x => x).All(c => c >= 3);
		}
	}
}
