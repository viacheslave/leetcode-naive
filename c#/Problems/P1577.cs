using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-ways-where-square-of-number-is-equal-to-product-of-two-numbers/
	///		Submission: https://leetcode.com/submissions/detail/393855948/
	/// </summary>
	internal class P1577
	{
		public int NumTriplets(int[] nums1, int[] nums2)
		{
			var sq1 = new BigInteger[nums1.Length];
			var sq2 = new BigInteger[nums2.Length];

			for (var i = 0; i < nums1.Length; i++)
				sq1[i] = new BigInteger(nums1[i]) * new BigInteger(nums1[i]);

			for (var i = 0; i < nums2.Length; i++)
				sq2[i] = new BigInteger(nums2[i]) * new BigInteger(nums2[i]);

			return Calc(sq1, nums2) + Calc(sq2, nums1);
		}

		private int Calc(BigInteger[] sq, int[] nums)
		{
			var ans = 0;
			var memo = new Dictionary<BigInteger, int>();

			foreach (var s in sq)
			{
				var local = 0;
				if (memo.ContainsKey(s))
				{
					ans += memo[s];
					continue;
				}

				for (var i = 0; i < nums.Length; i++)
				{
					if (s % nums[i] != 0)
						continue;

					var rem = s / nums[i];

					for (var j = i + 1; j < nums.Length; j++)
					{
						if (nums[j] == rem)
							local++;
					}
				}

				memo[s] = local;
				ans += local;
			}

			return ans;
		}
	}
}
