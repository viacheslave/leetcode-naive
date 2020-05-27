using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/random-pick-index/
	///		Submission: https://leetcode.com/submissions/detail/241448095/
	/// </summary>
	internal class P0398
	{
		new Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
		Random random = new Random((int)DateTime.Now.Ticks);

		public P0398(int[] nums)
		{
			for (int i = 0; i < nums.Length; i++)
			{
				if (!map.ContainsKey(nums[i]))
					map[nums[i]] = new List<int>();

				map[nums[i]].Add(i);
			}
		}

		public int Pick(int target)
		{
			var index = random.Next(map[target].Count);
			return map[target][index];
		}
	}
}
