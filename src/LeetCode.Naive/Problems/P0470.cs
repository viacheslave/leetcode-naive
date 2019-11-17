using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/implement-rand10-using-rand7/
	///		Submission: https://leetcode.com/submissions/detail/242465294/
	/// </summary>
	internal class P0470
	{
		public int Rand10()
		{
			var r1 = Rand7() - 1;
			var r2 = Rand7() - 1;

			var value49 = r1 * 7 + r2;
			if (value49 < 40)
				return (value49 % 10) + 1;

			r1 = value49 - 40;
			r2 = Rand7() - 1;

			var value63 = r1 * 7 + r2;
			if (value63 < 60)
				return (value63 % 10) + 1;

			r1 = value63 - 60;
			r2 = Rand7() - 1;

			return (r1 + r2) + 1;
		}

		private int Rand7()
		{
			throw new NotImplementedException();
		}
	}
}
