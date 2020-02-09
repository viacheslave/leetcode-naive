using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/nim-game/
	///		Submission: https://leetcode.com/submissions/detail/231799776/
	/// </summary>
	internal class P0292
	{
		public bool CanWinNim(int n)
		{

			return n % 4 != 0;
		}
	}
}
