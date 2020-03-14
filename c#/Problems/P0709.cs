using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/to-lower-case/
	///		Submission: https://leetcode.com/submissions/detail/229315492/
	/// </summary>
	internal class P0709
	{
		public string ToLowerCase(string str)
		{
			var chars = new char[str.Length];

			for (var i = 0; i < str.Length; i++)
				chars[i] = ((int)str[i] >= 65 && (int)str[i] <= 91) ? (char)((int)str[i] + 32) : str[i];

			return new string(chars);
		}
	}
}
