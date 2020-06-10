using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/encode-number/
	///		Submission: https://leetcode.com/submissions/detail/279536271/
	/// </summary>
	internal class P1256
	{
		public string Encode(int num)
		{
			if (num == 0)
				return "";

			var value = num + 1;
			var bin = new List<int>();

			while (value > 0)
			{
				bin.Add(value % 2);
				value /= 2;
			}

			bin.Reverse();

			return new string(bin.Skip(1).Select(b => Char.Parse(b.ToString())).ToArray());
		}
	}
}
