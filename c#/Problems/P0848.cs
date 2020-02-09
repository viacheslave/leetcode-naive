using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/shifting-letters/
	///		Submission: https://leetcode.com/submissions/detail/239748712/
	/// </summary>
	internal class P0848
	{
		public string ShiftingLetters(string S, int[] shifts)
		{
			for (var i = shifts.Length - 1; i >= 0; i--)
				shifts[i] = (shifts[i] + ((i == shifts.Length - 1) ? 0 : (shifts[i + 1] % 26))) % 26;

			var sb = new StringBuilder(S);

			for (int i = 0; i < shifts.Length; i++)
			{
				sb[i] = (char)(((shifts[i] + ((int)sb[i]) - 97) % 26) + 97);
			}

			return sb.ToString();
		}
	}
}
