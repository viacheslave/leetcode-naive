using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-all-duplicates-in-an-array/
	///		Submission: https://leetcode.com/submissions/detail/231252408/
	/// </summary>
	internal class P0442
	{
		public IList<int> FindDuplicates(int[] nums)
		{
			var res = new List<int>();
			var hs = new Dictionary<int, int>();
			for (var i = 0; i < nums.Length; i++)
			{
				if (!hs.ContainsKey(nums[i]))
					hs[nums[i]] = 0;
				hs[nums[i]]++;
			}
			return hs.Where(_ => _.Value > 1).Select(_ => _.Key).ToList();
		}
	}
}
