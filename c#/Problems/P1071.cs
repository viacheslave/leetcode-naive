using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/greatest-common-divisor-of-strings/
	///		Submission: https://leetcode.com/submissions/detail/258649258/
	/// </summary>
	internal class P1071
	{
		public string GcdOfStrings(string str1, string str2)
		{
			var cand = str1.Length < str2.Length ? str1 : str2;

			for (int i = cand.Length; i >= 1; i--)
			{
				var pref = cand.Substring(0, i);
				if (str1.Length % pref.Length != 0 || str2.Length % pref.Length != 0)
					continue;

				var c1 = string.Concat(Enumerable.Repeat(pref, str1.Length / pref.Length));
				var c2 = string.Concat(Enumerable.Repeat(pref, str2.Length / pref.Length));

				if (c1 == str1 && c2 == str2)
					return pref;
			}

			return "";
		}
	}
}
