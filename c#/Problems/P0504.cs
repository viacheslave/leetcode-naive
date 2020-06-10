using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/base-7/
	///		Submission: https://leetcode.com/submissions/detail/226731426/
	/// </summary>
	internal class P0504
	{
		public string ConvertToBase7(int num)
		{
			if (num == 0)
				return "0";

			var neg = num < 0;
			if (neg)
				num = num * (-1);

			var d = 1;

			while (true)
			{
				if (num < d * 7)
					break;

				d = d * 7;
			}

			string str = "";
			while (true)
			{
				var digit = num / d;
				var mod = num % d;

				str += digit.ToString();

				if (d == 1)
					break;

				num = num - d * digit;
				d = d / 7;
			}

			if (neg)
				str = "-" + str;

			return str;
		}
	}
}
