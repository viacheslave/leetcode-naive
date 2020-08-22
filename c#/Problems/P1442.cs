using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/
	///		Submission: https://leetcode.com/submissions/detail/384770205/
	/// </summary>
	internal class P1442
	{
		public int CountTriplets(int[] arr)
		{
			if (arr.Length < 2)
				return 0;

			var prefix = new int[arr.Length - 2 + 1];
			var suffix = new int[arr.Length - 2 + 1];

			prefix[0] = 0;
			suffix[0] = 0;

			for (var i = 0; i < arr.Length - 2; i++)
				prefix[i + 1] = prefix[i] ^ arr[i];

			for (var i = 0; i < arr.Length - 2; i++)
				suffix[i + 1] = suffix[i] ^ arr[arr.Length - 1 - i];

			var arrxor = 0;
			for (var i = 0; i < arr.Length; i++)
				arrxor ^= arr[i];

			var ans = 0;

			for (var i = 0; i < prefix.Length; i++)
			{
				for (var j = 0; j < suffix.Length - i; j++)
				{
					if ((arrxor ^ prefix[i] ^ suffix[j]) == 0)
						ans += (arr.Length - i - j - 1);
				}
			}

			return ans;
		}
	}
}
