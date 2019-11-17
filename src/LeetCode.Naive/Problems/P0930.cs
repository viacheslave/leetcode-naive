using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-subarrays-with-sum/
	///		Submission: https://leetcode.com/submissions/detail/247602761/
	/// </summary>
	internal class P0930
	{
		public int NumSubarraysWithSum(int[] A, int S)
		{
			var prefixSum = new int[A.Length];
			var hs = new Dictionary<int, List<int>>();

			for (int i = 0; i < A.Length; i++)
			{
				var value = i == 0
								 ? A[0]
								 : prefixSum[i - 1] + A[i];

				if (!hs.ContainsKey(value))
					hs[value] = new List<int>();

				hs[value].Add(i);
				prefixSum[i] = value;
			}

			var ans = 0;

			for (int i = 0; i < prefixSum.Length; i++)
			{
				if (prefixSum[i] == S)
					ans++;

				var target = prefixSum[i] - S;
				if (hs.TryGetValue(target, out var indexList))
				{
					ans += indexList.Count(_ => _ < i);
				}
			}

			return ans;
		}
	}
}
