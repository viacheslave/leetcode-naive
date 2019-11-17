using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/random-pick-with-weight/
	///		Submission: https://leetcode.com/submissions/detail/244902597/
	/// </summary>
	internal class P0528
	{
		private readonly int[] _w;
		private readonly int _sum;
		private readonly Random _random = new Random();

		public _0528(int[] w)
		{
			_w = w;
			_sum = w.Sum();
		}

		public int PickIndex()
		{
			var rnd = _random.Next(_sum);

			var sum = 0;
			var windex = 0;

			while (rnd >= sum)
			{
				sum += _w[windex];
				windex++;
			}

			windex--;

			return windex;
		}
	}
}
