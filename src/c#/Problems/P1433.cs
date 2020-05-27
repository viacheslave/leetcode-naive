using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/check-if-a-string-can-break-another-string/
	///		Submission: https://leetcode.com/submissions/detail/345048125/
	/// </summary>
	internal class P1433
	{
		public bool CheckIfCanBreak(string s1, string s2)
		{
			var as1 = s1.ToCharArray();
			var as2 = s2.ToCharArray();

			Array.Sort(as1);
			Array.Sort(as2);

			return
				as1.Zip(as2, (c1, c2) => c1 <= c2).All(x => x) ||
				as1.Zip(as2, (c1, c2) => c1 >= c2).All(x => x);
		}
	}
}
