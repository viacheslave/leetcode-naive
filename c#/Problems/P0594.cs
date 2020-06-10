using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/longest-harmonious-subsequence/
	///		Submission: https://leetcode.com/submissions/detail/237134277/
	/// </summary>
	internal class P0594
	{
		public int FindLHS(int[] nums)
		{
			var map = new SortedDictionary<int, int>();

			foreach (var num in nums)
			{
				if (!map.ContainsKey(num)) map[num] = 0;
				map[num]++;
			}

			var keys = map.Keys.ToList();
			var length = 0;

			for (var i = 1; i < keys.Count; i++)
			{
				if (keys[i] - keys[i - 1] == 1)
				{
					if (map[keys[i]] + map[keys[i - 1]] > length)
						length = map[keys[i]] + map[keys[i - 1]];
				}
			}

			return length;
		}
	}
}
