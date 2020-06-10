using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/create-target-array-in-the-given-order/
	///		Submission: https://leetcode.com/submissions/detail/321243385/
	/// </summary>
	internal class P1389
	{
		public int[] CreateTargetArray(int[] nums, int[] index)
		{
			var ans = new List<int>();
			for (var i = 0; i < nums.Length; i++)
				ans.Insert(index[i], nums[i]);
			return ans.ToArray();
		}
	}
}
