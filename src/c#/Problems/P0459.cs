using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/repeated-substring-pattern/
	///		Submission: https://leetcode.com/submissions/detail/237986990/
	/// </summary>
	internal class P0459
	{
		public bool RepeatedSubstringPattern(string s)
		{
			if (s.Length == 1)
				return false;

			for (var l = 0; l < s.Length / 2; l++)
			{
				if ((s.Length) % (l + 1) != 0)
					continue;

				var sindex = 0;

				while (sindex < s.Length)
				{
					if (s[sindex] != s[sindex % (l + 1)])
						break;

					sindex++;
				}

				if (sindex == s.Length)
					return true;
			}

			return false;
		}
	}
}
