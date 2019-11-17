using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-smallest-letter-greater-than-target/
	///		Submission: https://leetcode.com/submissions/detail/233647440/
	/// </summary>
	internal class P0744
	{
		public char NextGreatestLetter(char[] letters, char target)
		{
			var hs = new HashSet<char>(letters);

			for (var i = 1; i < 26; i++)
			{
				var l = target + i;
				if (l > 122)
					l = l - 26;

				if (hs.Contains((char)l))
					return (char)l;
			}

			return default(char);
		}
	}
}
