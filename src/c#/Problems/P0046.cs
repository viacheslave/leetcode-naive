using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/permutations/
	///		Submission: https://leetcode.com/submissions/detail/231543251/
	/// </summary>
	internal class P0046
	{
		public IList<IList<int>> Permute(int[] nums)
		{
			int[] filled = new int[nums.Length];
			for (var i = 0; i < nums.Length; i++)
				filled[i] = -1;

			IList<IList<int>> res = new List<IList<int>>();

			Rec(res, filled, nums, nums.Length);

			return res;
		}

		private void Rec(IList<IList<int>> res, int[] filled, int[] nums, int num)
		{
			if (num == 0)
			{
				var cand = new List<int>();
				for (var i = 0; i < filled.Length; i++)
					cand.Add(nums[filled[i]]);

				res.Add(cand);
				return;
			}

			for (var i = 0; i < filled.Length; i++)
			{
				if (filled[i] != -1)
					continue;

				filled[i] = num - 1;

				Rec(res, filled, nums, num - 1);

				filled[i] = -1;
			}
		}
	}
}
