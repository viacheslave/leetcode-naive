using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/elimination-game/
	///		Submission: https://leetcode.com/submissions/detail/243867088/
	/// </summary>
	internal class P0390
	{
		public int LastRemaining(int n)
		{
			var diff = 1;
			var first = 1;
			var dir = 0;

			while (n > 1)
			{
				if (n % 2 == 1)
				{
					first += diff;
				}
				else
				{
					if (dir == 0)
						first += diff;
				}

				n /= 2;
				diff *= 2;
				dir = 1 - dir;
			}

			return first;
		}
	}
}
