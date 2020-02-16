﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/split-a-string-in-balanced-strings/
	///		Submission: https://leetcode.com/submissions/detail/278793608/
	/// </summary>
	internal class P1221
	{
		public int BalancedStringSplit(string s)
		{
			var sb = new StringBuilder();
			var lcount = 0;
			var rcount = 0;

			var ans = 0;

			foreach (var ch in s)
			{
				sb.Append(ch);
				if (ch == 'L') lcount++;
				if (ch == 'R') rcount++;

				if (lcount == rcount && lcount != 0)
				{
					ans++;
					sb = new StringBuilder();
					lcount = 0;
					rcount = 0;
				}
			}

			return ans;
		}
	}
}