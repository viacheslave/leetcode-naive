using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/zigzag-conversion/
	///		Submission: https://leetcode.com/submissions/detail/228170541/
	/// </summary>
	internal class P0006
	{
		public string Convert(string s, int numRows)
		{
			if (numRows <= 1)
				return s;

			var arrs = new StringBuilder[numRows];

			for (var index = 0; index < s.Length; index += (numRows - 1) * 2)
			{
				for (var left = 0; left <= numRows - 1; left++)
				{
					if (index + left == s.Length)
						break;

					if (arrs[left] == null)
						arrs[left] = new StringBuilder();

					arrs[left].Append(s[index + left]);
				}

				for (var right = 0; right < (numRows - 1) - 1; right++)
				{
					if (index + numRows + right >= s.Length)
						break;

					arrs[numRows - 2 - right].Append(s[index + numRows + right]);
				}
			}


			var result = new StringBuilder();
			foreach (var arr in arrs)
				result.Append(arr?.ToString());

			return result.ToString();
		}
	}
}
