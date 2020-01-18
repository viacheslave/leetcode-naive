using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/
	///		Submission: https://leetcode.com/submissions/detail/293584484/
	/// </summary>
	internal class P1318
	{
		public int MinFlips(int a, int b, int c)
		{
			var bit_a = GetArray(a);
			var bit_b = GetArray(b);
			var bit_c = GetArray(c);

			var ans = 0;
			for (int i = 0; i < 32; i++)
			{
				if (bit_c[i] == 0)
				{
					if (bit_a[i] + bit_b[i] > 0)
					{
						ans += (bit_a[i] + bit_b[i]);
						continue;
					}
					else
					{
						continue;
					}
				}
				else
				{
					if (bit_a[i] + bit_b[i] >= 1)
					{
						continue;
					}
					else
					{
						ans += 1;
					}
				}
			}

			return ans;
		}

		private int[] GetArray(int a)
		{
			var bit_a = Convert.ToString(a, 2).Select(x => int.Parse(x.ToString())).ToArray();
			var ch_a = new int[32];
			for (var i = bit_a.Length - 1; i >= 0; i--)
			{
				ch_a[31 - bit_a.Length + i + 1] = bit_a[i];
			}
			return ch_a;
		}
	}
}
