using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/implement-strstr/
	///		Submission: https://leetcode.com/submissions/detail/227432932/
	/// </summary>
	internal class P0028
	{
		public int StrStr(string haystack, string needle)
		{
			if (needle == "")
				return 0;

			for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
			{
				var matches = true;
				for (var currentNeedle = 0; currentNeedle < needle.Length; currentNeedle++)
					matches = matches & (haystack[i + currentNeedle] == needle[currentNeedle]);

				if (matches)
					return i;
			}

			return -1;
		}
	}
}
