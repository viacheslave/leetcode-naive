using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/string-to-integer-atoi/
	///		Submission: https://leetcode.com/submissions/detail/232027701/
	/// </summary>
	internal class P0008
	{
		public int MyAtoi(string str)
		{
			str = str.TrimStart();

			var neg = str.StartsWith("-");

			if (str.StartsWith("-") || str.StartsWith("+"))
				str = str.Substring(1);

			str = str.Split(new[] { ' ', '.' })[0];

			var index = 0;
			while (index < str.Length)
			{
				if (!Char.IsDigit(str[index]))
					break;

				index++;
			}

			var end = index - 1;
			index = 0;

			int value = 0;
			int power = 0;

			while (index <= end)
			{
				if (!Char.IsDigit(str[index]))
					return 0;

				var digit = int.Parse(str[index].ToString());

				if (!neg && (long)value * 10 + digit > (long)int.MaxValue)
				{
					return int.MaxValue;
				}

				if (neg && (-1) * ((long)value * 10 + digit) < (long)int.MinValue)
				{
					return int.MinValue;
				}

				value = value * 10 + digit;

				power++;
				index++;
			}

			return value * (neg ? -1 : 1);
		}
	}
}
