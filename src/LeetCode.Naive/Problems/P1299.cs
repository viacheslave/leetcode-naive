using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side/
	///		Submission: https://leetcode.com/submissions/detail/289486570/
	/// </summary>
	internal class P1299
	{
		public int[] ReplaceElements(int[] arr)
		{
			if (arr.Length == 0)
				return arr;

			if (arr.Length == 1)
				return new int[] { -1 };

			var ans = new int[arr.Length];

			var max = int.MinValue;
			for (int i = arr.Length - 2; i >= 0; i--)
			{
				max = Math.Max(max, arr[i + 1]);
				ans[i] = max;
			}

			ans[ans.Length - 1] = -1;
			return ans;
		}
	}
}
