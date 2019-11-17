using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-segments-in-a-string/
	///		Submission: https://leetcode.com/submissions/detail/228894050/
	/// </summary>
	internal class P0434
	{
		public int CountSegments(string s)
		{
			return s.Split(' ')
					.Where(seg => seg != string.Empty)
					.Count();
		}
	}
}
