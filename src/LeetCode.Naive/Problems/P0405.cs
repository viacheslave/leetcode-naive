using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/convert-a-number-to-hexadecimal/
	///		Submission: https://leetcode.com/submissions/detail/234054395/
	/// </summary>
	internal class P0405
	{
		public string ToHex(int num)
		{
			if (num == 0) return "0";

			if (num == int.MaxValue) return "7fffffff";
			if (num == int.MinValue) return "80000000";

			var isNegative = num < 0;

			num = Math.Abs(num);
			if (isNegative)
				num--;

			var ch = new int[32];

			for (var i = 31; i >= 0; i--)
			{
				ch[i] = num % 2;
				num = num >> 1;
			}

			if (isNegative)
				for (var i = 31; i >= 0; i--)
					ch[i] = 1 - ch[i];

			var d = new Dictionary<int, char>()
			{
				[10] = 'a',
				[11] = 'b',
				[12] = 'c',
				[13] = 'd',
				[14] = 'e',
				[15] = 'f'
			};

			var sb = new StringBuilder();
			for (var i = 31; i >= 0; i -= 4)
			{
				var value = 8 * ch[i - 3] + 4 * ch[i - 2] + 2 * ch[i - 1] + ch[i];
				if (value < 10)
					sb.Insert(0, value.ToString());
				else
					sb.Insert(0, d[value]);
			}

			return sb.ToString().TrimStart('0');
		}
	}
}
