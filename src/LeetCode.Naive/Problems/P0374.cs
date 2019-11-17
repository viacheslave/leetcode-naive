using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/guess-number-higher-or-lower/
	///		Submission: https://leetcode.com/submissions/detail/231116531/
	/// </summary>
	internal class P0374
	{
		/* 
		 * JAVA
		public class Solution extends GuessGame
		{

			public int guessNumber(int n)
			{
				int lo = 1;
				int hi = n;
				Integer next = hi / 2;

				while (true)
				{
					next = lo + (hi - lo) / 2;

					int res = guess(next);
					if (res == 0)
						return next;

					if (res == 1)
					{
						lo = next;
					}

					if (res == -1)
					{
						hi = next;
					}

					if (hi - lo <= 1)
					{
						int r = guess(lo);
						if (r == 0) return lo;

						int r2 = guess(hi);
						if (r2 == 0) return hi;
					}
				}
			}
		}*/
	}
}
