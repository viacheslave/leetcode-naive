using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/contiguous-array/
	///		Submission: https://leetcode.com/submissions/detail/247599023/
	/// </summary>
	internal class P0525
	{
		public int FindMaxLength(int[] nums)
		{
			var a = nums.Select(_ => _ == 1 ? 1 : -1).ToArray();

			var prefixSum = new int[a.Length];
			var hs = new Dictionary<int, List<int>>();

			for (int i = 0; i < a.Length; i++)
			{
				var value = i == 0
						 ? a[0]
						 : prefixSum[i - 1] + a[i];

				if (!hs.ContainsKey(value))
					hs[value] = new List<int>();

				hs[value].Add(i);
				prefixSum[i] = value;
			}

			var max = 0;

			for (int i = 0; i < prefixSum.Length; i++)
			{
				if (prefixSum[i] == 0)
				{
					max = Math.Max(max, i + 1);
					continue;
				}

				if (hs.TryGetValue(prefixSum[i], out var indexList) && indexList.Count > 0 && indexList[0] < i)
				{
					max = Math.Max(max, i - indexList[0]);
				}
			}

			return max;
		}
	}
}
