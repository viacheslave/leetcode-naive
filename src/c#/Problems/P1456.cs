using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
	///		Submission: https://leetcode.com/submissions/detail/344032500/
	/// </summary>
	internal class P1456
	{
		public int MaxVowels(string s, int k)
		{
			var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

			var start = 0;
			var end = k - 1;

			var current = s.Take(k).Count(x => vowels.Contains(x));
			var ans = current;

			while (end + 1 < s.Length)
			{
				start++;
				end++;

				if (vowels.Contains(s[end]))
					current++;

				if (vowels.Contains(s[start - 1]))
					current--;

				ans = Math.Max(ans, current);
			}

			return ans;
		}
	}
}
