using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/break-a-palindrome/
	///		Submission: https://leetcode.com/submissions/detail/297536588/
	/// </summary>
	internal class P1328
	{
		public string BreakPalindrome(string palindrome)
		{
			if (string.IsNullOrEmpty(palindrome))
				return "";

			var sb = new StringBuilder(palindrome);
			for (var i = 0; i < palindrome.Length; i++)
			{
				if ((i + 1) * 2 == palindrome.Length + 1)
					continue;

				if (sb[i] != 'a')
				{
					sb[i] = 'a';
					break;
				}
			}

			if (IsPalindromic(sb.ToString()))
			{
				for (var i = palindrome.Length - 1; i >= 0; i--)
				{
					if (sb[i] != 'z')
					{
						sb[i] = (char)(((byte)sb[i]) + 1);
						break;
					}
				}
			}

			return IsPalindromic(sb.ToString()) ? "" : sb.ToString();
		}

		private bool IsPalindromic(string s)
		{
			for (var i = 0; i < s.Length / 2; i++)
				if (s[i] != s[s.Length - 1 - i])
					return false;
			return true;
		}
	}
}
