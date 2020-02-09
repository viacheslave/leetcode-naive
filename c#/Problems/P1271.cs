using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/hexspeak/
	///		Submission: https://leetcode.com/submissions/detail/283168256/
	/// </summary>
	internal class P1271
	{
		public string ToHexspeak(string num)
		{
			var n = long.Parse(num);

			var sb = new StringBuilder();

			while (n > 0)
			{
				var digit = n % 16L;
				sb.Insert(0, GetDigit(digit));

				n = n - digit;
				n = n / 16L;
			}

			var allowedset = new HashSet<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'I', 'O' };
			foreach (var ch in sb.ToString())
			{
				if (!allowedset.Contains(ch))
					return "ERROR";
			}

			return sb.ToString();
		}

		private string GetDigit(long digit)
		{
			if (digit == 1) return "I";
			if (digit == 0) return "O";

			switch (digit)
			{
				case 10: return "A";
				case 11: return "B";
				case 12: return "C";
				case 13: return "D";
				case 14: return "E";
				case 15: return "F";
			}

			return digit.ToString();
		}
	}
}
