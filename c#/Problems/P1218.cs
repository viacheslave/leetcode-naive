using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/longest-arithmetic-subsequence-of-given-difference/
	///		Submission: https://leetcode.com/submissions/detail/295210158/
	/// </summary>
	internal class P1218
	{
		public int LongestSubsequence(int[] arr, int difference)
		{
			var max = 1;

			var mem = new Dictionary<int, int>();
			mem[arr[0]] = 1;


			for (var i = 1; i < arr.Length; i++)
			{
				mem[arr[i]] = 1;

				if (mem.ContainsKey(arr[i] - difference))
				{
					mem[arr[i]] = mem[arr[i] - difference] + 1;
					if (mem[arr[i]] > max) max = mem[arr[i]];
				}
			}

			return max;
		}
	}
}
