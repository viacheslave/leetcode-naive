using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sqrtx/
	///		Submission: https://leetcode.com/submissions/detail/226158761/
	/// </summary>
	internal class P0069
	{
		public int MySqrt(int x)
		{
			if (x == 0) return 0;
			if (x <= 3) return 1;

			var min = 2;
			var max = 4;

			while ((max * max > 0))
			{
				if (max * max > x)
					break;

				min = min * 2;
				max = max * 2;
			}

			//return max;

			var cur = min;

			while (true)
			{
				//if (min > 32000)
				//   return min;

				cur = (min + max) / 2;

				if (cur == min || cur == max)
					return cur;

				var res = cur * cur;

				if (res == x)
					return cur;

				if (res < 0)
				{
					max = cur;
					continue;
				}

				if (res > x)
				{
					max = cur;
					//return max;
				}
				else
					min = cur;
			}
		}
	}
}
