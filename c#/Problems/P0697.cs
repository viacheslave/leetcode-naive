using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/degree-of-an-array/
	///		Submission: https://leetcode.com/submissions/detail/230911775/
	/// </summary>
	internal class P0697
	{
		public int FindShortestSubArray(int[] nums)
		{
			var fr = new Dictionary<int, int>();
			var max = 0;

			foreach (var n in nums)
			{
				if (!fr.ContainsKey(n))
					fr[n] = 0;

				fr[n]++;
				if (fr[n] > max)
					max = fr[n];
			}

			var items = new List<int>();
			foreach (var kvp in fr)
			{
				if (kvp.Value == max)
					items.Add(kvp.Key);
			}

			var minRank = -1;
			for (var i = 0; i < items.Count; i++)
			{
				var rank = GetRank(nums, items[i]);
				if (minRank == -1)
					minRank = rank;
				else if (rank < minRank)
					minRank = rank;
			}

			return minRank;
		}

		int GetRank(int[] nums, int el)
		{
			var start = -1;
			var end = -1;

			for (var i = 0; i < nums.Length; i++)
			{
				if (el == nums[i])
				{
					if (start == -1)
					{
						start = i;
						end = i;
					}
					else
					{
						end = i;
					}
				}
			}

			return end - start + 1;
		}
	}
}
