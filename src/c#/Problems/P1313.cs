using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/decompress-run-length-encoded-list/
	///		Submission: https://leetcode.com/submissions/detail/293250091/
	/// </summary>
	internal class P1313
	{
		public int[] DecompressRLElist(int[] nums)
		{
			var ans = new List<int>();

			for (var i = 0; i < nums.Length; i += 2)
			{
				ans.AddRange(Enumerable.Repeat(nums[i + 1], nums[i]));
			}

			return ans.ToArray();
		}
	}
}
