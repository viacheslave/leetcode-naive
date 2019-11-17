using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/unique-email-addresses/
	///		Submission: https://leetcode.com/submissions/detail/230924914/
	/// </summary>
	internal class P0929
	{
		public int NumUniqueEmails(string[] emails)
		{
			var hs = new HashSet<string>();

			foreach (var email in emails)
			{
				var plusIndex = email.IndexOf('+');
				var domainIndex = email.IndexOf('@');

				var c = string.Empty;
				if (plusIndex != -1)
					c = email.Substring(0, plusIndex).Replace(".", "") + "@" + email.Substring(domainIndex + 1);
				else
					c = email.Substring(0, domainIndex).Replace(".", "") + "@" + email.Substring(domainIndex + 1);

				hs.Add(c);
			}

			return hs.Count;
		}
	}
}
