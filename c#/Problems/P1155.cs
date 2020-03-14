using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
	///		Submission: https://leetcode.com/submissions/detail/258946680/
	/// </summary>
	internal class P1155
	{
		public int NumRollsToTarget(int d, int f, int target)
		{
			var dp = new Dictionary<(int, int), int>();

			return Get(dp, d, f, target);
		}

		private int Get(Dictionary<(int, int), int> dp, int d, int f, int target)
		{
			if (target == 0)
				return 0;

			if (d == 1)
			{
				int val = f >= target ? 1 : 0;
				dp[(d, target)] = val;
				return val;
			}

			BigInteger count = 0;
			for (int i = 1; i <= f; i++)
			{
				if (i > target)
					break;

				int val;
				if (dp.ContainsKey((d - 1, target - i)))
					val = dp[(d - 1, target - i)];
				else
					val = Get(dp, d - 1, f, target - i);

				count += val;
			}

			dp[(d, target)] = (int)(count % 1_000_000_007);
			return dp[(d, target)];
		}
	}
}
