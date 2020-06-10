using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-k-digits/
	///		Submission: https://leetcode.com/submissions/detail/238779690/
	/// </summary>
	internal class P0402
	{
		public string RemoveKdigits(string num, int k)
		{
			var digits = num.Select(_ => int.Parse(_.ToString())).ToList();

			for (var i = 0; i < k; i++)
			{
				if (digits.Count == 1)
				{
					digits = new List<int>();
				}
				else
				{
					var lastMax = 0;
					for (var j = 1; j < digits.Count; j++)
					{
						if (digits[j] >= digits[j - 1])
							lastMax = j;
						else break;
					}

					digits.RemoveAt(lastMax);
				}
			}

			var v = string.Join("", digits).TrimStart(new char[] { '0' });
			return v == string.Empty ? "0" : v;
		}
	}
}
