using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-69-number/
	///		Submission: https://leetcode.com/submissions/detail/295925341/
	/// </summary>
	internal class P1323
	{
		public int Maximum69Number(int num)
		{
			var index = num.ToString().IndexOf('6');
			if (index == -1)
				return num;

			var sb = new StringBuilder(num.ToString());
			sb[index] = '9';
			return int.Parse(sb.ToString());
		}
	}
}
