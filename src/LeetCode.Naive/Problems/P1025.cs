using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/divisor-game/
	///		Submission: https://leetcode.com/submissions/detail/229949104/
	/// </summary>
	internal class P1025
	{
		public class Solution
		{
			public bool DivisorGame(int N)
			{
				return N % 2 == 0;
			}
		}
	}
}
