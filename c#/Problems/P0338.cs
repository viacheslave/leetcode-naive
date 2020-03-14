using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/counting-bits/
	///		Submission: https://leetcode.com/submissions/detail/230454079/
	/// </summary>
	internal class P0338
	{
		public int[] CountBits(int num)
		{
			if (num == 0)
				return new int[] { 0 };

			if (num == 1)
				return new int[] { 0, 1 };

			var c = new int[num + 1];
			c[0] = 0;
			c[1] = 1;

			var i = 2;
			var target = 2;
			var reli = 0;

			while (i <= num)
			{
				if (i == target)
				{
					reli = 0;
					target = target * 2;
				}

				c[i] = 1 + c[reli];

				i++;
				reli++;
			}

			return c;
		}
	}
}
