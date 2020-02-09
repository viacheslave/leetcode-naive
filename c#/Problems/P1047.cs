using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
	///		Submission: https://leetcode.com/submissions/detail/231272824/
	/// </summary>
	internal class P1047
	{
		public string RemoveDuplicates(string S)
		{
			if (S.Length < 2)
				return S;

			var sb = new StringBuilder(S);

			while (true)
			{
				if (S.Length < 2)
					return sb.ToString();

				var pos = -1;
				for (var i = 1; i < sb.Length; i++)
				{
					if (sb[i] == sb[i - 1])
					{
						pos = i - 1;
						break;
					}
				}

				if (pos == -1)
					break;

				sb.Remove(pos, 2);

			}

			return sb.ToString();
		}
	}
}
