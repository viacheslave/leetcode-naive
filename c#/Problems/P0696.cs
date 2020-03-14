using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/count-binary-substrings/
	///		Submission: https://leetcode.com/submissions/detail/231525986/
	/// </summary>
	internal class P0696
	{
		public int CountBinarySubstrings(string s)
		{
			if (s.Length < 2)
				return 0;

			var res = 0;

			for (var i = 1; i < s.Length; i++)
			{
				if (s[i] != s[i - 1])
					res += Get(s, i - 1, i);
			}


			return res;
		}

		int Get(string s, int i, int j)
		{
			var res = 1;

			while (true)
			{
				i--; j++;

				if (i < 0 || j >= s.Length)
					return res;

				if (s[i] == s[i + 1] && s[j] == s[j - 1])
					res++;

				else break;
			}

			return res;
		}
	}
}
