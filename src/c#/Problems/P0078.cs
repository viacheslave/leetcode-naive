using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/subsets/
	///		Submission: https://leetcode.com/submissions/detail/234944457/
	/// </summary>
	internal class P0078
	{
		public IList<IList<int>> Subsets(int[] nums)
		{
			Array.Sort(nums);

			var res = new List<IList<int>>() { new int[0] };

			var current = new List<int>();
			Fill(res, nums, current, 0, -1);

			return res;
		}

		private void Fill(List<IList<int>> res, int[] nums, List<int> current, int iter, int index)
		{
			for (var i = index + 1; i < nums.Length; i++)
			{
				current.Add(nums[i]);

				res.Add(new List<int>(current));

				Fill(res, nums, current, iter + 1, i);

				current.RemoveAt(current.Count - 1);
			}
		}
	}
}
