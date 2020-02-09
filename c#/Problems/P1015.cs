using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/smallest-integer-divisible-by-k/
	///		Submission: https://leetcode.com/submissions/detail/243529804/
	/// </summary>
	internal class P1015
	{
		public int SmallestRepunitDivByK(int K)
		{
			int module = 1 % K;
			if (module == 0)
				return 1;

			var length = 2;
			var modules = new HashSet<int>() { module };

			while (true)
			{
				module = (((module % K) * (10 % K)) % K + (1 % K)) % K;
				if (module == 0)
					return length;

				if (modules.Contains(module))
					return -1;

				modules.Add(module);
				length++;
			}
		}
	}
}
