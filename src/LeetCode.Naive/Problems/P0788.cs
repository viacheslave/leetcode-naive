using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/rotated-digits/
	///		Submission: https://leetcode.com/submissions/detail/231086614/
	/// </summary>
	internal class P0788
	{
		public int RotatedDigits(int N)
		{
			var count = 0;

			for (var i = 1; i <= N; i++)
			{
				var rotated = GetRotated(i);
				if (rotated != i)
					count++;
			}

			return count;
		}

		private int GetRotated(int num)
		{
			var s = num.ToString();
			if (s.Contains('3') || s.Contains('4') || s.Contains('7'))
				return num;

			var sb = new StringBuilder(s);

			for (var i = 0; i < sb.Length; i++)
			{
				if (sb[i] == '2')
				{
					sb[i] = '5';
					continue;
				}

				if (sb[i] == '5')
				{
					sb[i] = '2';
					continue;
				}

				if (sb[i] == '6')
				{
					sb[i] = '9';
					continue;
				}

				if (sb[i] == '9')
				{
					sb[i] = '6';
					continue;
				}
			}

			return int.Parse(sb.ToString());
		}
	}
}
