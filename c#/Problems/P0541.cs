using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reverse-string-ii/
	///		Submission: https://leetcode.com/submissions/detail/227563762/
	/// </summary>
	internal class P0541
	{
		public string ReverseStr(string s, int k)
		{
			StringBuilder sb = new StringBuilder();

			var currentIndex = 0;

			while (currentIndex < s.Length)
			{
				var last = currentIndex + k - 1;
				if (last >= s.Length)
				{
					last = s.Length - 1;
				}

				for (var i = last; i >= currentIndex; i--)
				{
					sb.Append(s[i]);
				}

				var otherStart = currentIndex + k;
				var otherEnd = currentIndex + 2 * k - 1;

				if (otherStart < s.Length)
				{
					if (otherEnd >= s.Length)
						otherEnd = s.Length - 1;

					if (otherStart < s.Length)
					{
						for (var i = otherStart; i <= otherEnd; i++)
							sb.Append(s[i]);
					}


				}
				currentIndex = otherEnd + 1;
			}

			return sb.ToString();
		}
	}
}
