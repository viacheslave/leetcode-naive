using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/multiply-strings/
	///		Submission: https://leetcode.com/submissions/detail/228181307/
	/// </summary>
	internal class P0043
	{
		public string Multiply(string num1, string num2)
		{
			var rows = new List<string>(num2.Length);

			for (var i = num2.Length - 1; i >= 0; i--)
			{
				rows.Add(GetRow(num1, int.Parse(num2[i].ToString())));
			}

			return GetResult(rows);
		}

		private string GetRow(string top, int down)
		{
			if (down == 0)
				return "0";

			if (down == 1)
				return top;

			var sb = new StringBuilder();

			var carry = 0;

			for (var i = top.Length - 1; i >= 0; i--)
			{
				var mult = down * int.Parse(top[i].ToString()) + carry;
				var digit = mult % 10;
				carry = mult / 10;

				sb.Insert(0, digit.ToString());
			}

			if (carry > 0)
				sb.Insert(0, carry.ToString());

			return sb.ToString();
		}

		private string GetResult(List<string> rows)
		{
			var sb = new StringBuilder();

			int index = 0;
			var carry = 0;

			while (true)
			{
				var hasDigits = false;
				var sum = 0;

				for (var i = 0; i < rows.Count; i++)
				{
					var dIndex = rows[i].Length + i - index - 1;
					var within = 0 <= dIndex && dIndex < rows[i].Length;

					hasDigits = hasDigits || (within);

					if (within)
					{
						sum += int.Parse(rows[i][dIndex].ToString());
					}
				}

				sum += carry;

				if (!hasDigits)
					break;

				var digit = sum % 10;
				carry = sum / 10;

				sb.Insert(0, digit);

				index++;
			}

			if (carry > 0)
				sb.Insert(0, carry);

			var result = sb.ToString().TrimStart(new[] { '0' });
			if (result == "")
				return "0";

			return result;
		}
	}
}
