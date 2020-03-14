using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/student-attendance-record-i/
	///		Submission: https://leetcode.com/submissions/detail/229741397/
	/// </summary>
	internal class P0551
	{
		public bool CheckRecord(string s)
		{
			if (s.Length == 0)
				return true;

			var hasA = false;
			var ls = 0;

			for (var ch = 0; ch < s.Length; ch++)
			{
				if (s[ch] == 'L')
				{
					ls++;
					if (ls > 2)
						return false;

				}

				if (s[ch] == 'P' || s[ch] == 'A')
				{
					ls = 0;

					if (s[ch] == 'A')
					{
						if (hasA)
							return false;

						hasA = true;
					}
				}
			}

			return true;
		}
	}
}
