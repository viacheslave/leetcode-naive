using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reverse-only-letters/
	///		Submission: https://leetcode.com/submissions/detail/232276820/
	/// </summary>
	internal class P0917
	{
		public string ReverseOnlyLetters(string S)
		{
			var ch = new char[S.Length];

			for (var i = 0; i < S.Length; i++)
				if (!Char.IsLetter(S[i]))
					ch[i] = S[i];

			int chIndex = 0;
			int sIndex = S.Length - 1;

			while (sIndex >= 0)
			{
				while (sIndex >= 0 && !Char.IsLetter(S[sIndex]))
					sIndex--;

				while (chIndex < ch.Length && ch[chIndex] != default)
					chIndex++;

				if (sIndex < 0 || chIndex >= ch.Length)
					break;

				ch[chIndex++] = S[sIndex--];
			}

			return new string(ch);
		}
	}
}
