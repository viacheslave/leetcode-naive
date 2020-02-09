using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/permutations-ii/
	///		Submission: https://leetcode.com/submissions/detail/241489837/
	/// </summary>
	internal class P0047
	{
		public IList<IList<int>> PermuteUnique(int[] nums)
		{
			Array.Sort(nums);

			var filled = new List<int>();

			IList<IList<int>> res = new List<IList<int>>();

			Rec(res, filled, nums, nums.Length);

			return res;
		}

		private void Rec(IList<IList<int>> res, List<int> filled, int[] nums, int left)
		{
			if (left == 0)
			{
				var cand = new List<int>();
				for (var i = 0; i < filled.Count; i++)
					cand.Add(nums[filled[i]]);

				res.Add(cand);
				return;
			}

			for (var i = 0; i < nums.Length; i++)
			{
				if (filled.Contains(i))
					continue;

				var current = i;
				while ((current + 1) < nums.Length)
				{
					if (filled.Contains(current + 1))
					{
						current++;
						continue;
					}

					if (nums[current + 1] != nums[i])
					{
						break;
					}

					current++;
					i = current;
				}

				filled.Add(i);

				Rec(res, filled, nums, left - 1);

				filled.Remove(i);
			}
		}
	}
}
