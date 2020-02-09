using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/check-if-word-is-valid-after-substitutions/
	///		Submission: https://leetcode.com/submissions/detail/247310953/
	/// </summary>
	internal class P1003
	{
		public bool IsValid(string S)
		{
			var abc = "abc";

			while (true)
			{
				var index = S.IndexOf(abc);
				if (index == -1)
					return false;

				S = S.Remove(index, abc.Length);
				if (S.Length == 0)
					return true;
			}
		}
	}
}
