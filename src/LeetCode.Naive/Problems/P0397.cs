using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/integer-replacement/
	///		Submission: https://leetcode.com/submissions/detail/231313777/
	/// </summary>
	internal class P0397
	{
		public int IntegerReplacement(int n)
		{

			int r = 0;

			var l = (long)n;

			while (l != 1)
			{
				if (l % 2 == 0)
				{
					l = l / 2;
					r++;
					continue;
				}

				if (l == 3)
				{
					l = 2;
					r++;
					continue;
				}

				var dir = GetDir(l);
				if (dir == 1)
					l = l + 1;
				else
					l = l - 1;

				r++;
			}

			return r;
		}

		int GetDir(long n)
		{
			var hipower = GetPower(n + 1);
			var lopower = GetPower(n - 1);

			return hipower >= lopower ? 1 : -1;
		}

		int GetPower(long n)
		{
			int p = 0;
			while (n % 2 == 0)
			{
				p++;
				n = n / 2;
			}

			return p;
		}
	}
}
