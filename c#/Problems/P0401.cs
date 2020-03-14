using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/binary-watch/
	///		Submission: https://leetcode.com/submissions/detail/231480637/
	/// </summary>
	internal class P0401
	{
		public IList<string> ReadBinaryWatch(int num)
		{
			int[] filled = new int[10];

			HashSet<string> res = new HashSet<string>();

			Rec(res, filled, num, 0);

			return res.ToList();
		}

		private void Rec(HashSet<string> res, int[] filled, int num, int k)
		{
			if (num == 0)
			{
				AddResult(res, filled);
				return;
			}

			for (var i = k; i < filled.Length; i++)
			{
				if (filled[i] == 1)
					continue;

				filled[i] = 1;

				Rec(res, filled, num - 1, k + 1);

				filled[i] = 0;
			}
		}

		private void AddResult(HashSet<string> res, int[] filled)
		{
			var minutes = 0;
			var hours = 0;

			for (var i = 0; i < 6; i++)
				if (filled[i] == 1)
					minutes += (int)Math.Pow(2, i);

			for (var i = 6; i < 10; i++)
				if (filled[i] == 1)
					hours += (int)Math.Pow(2, i - 6);

			if (hours > 11 || minutes > 59)
				return;

			var s = hours.ToString() + ":" + minutes.ToString("D2");
			res.Add(s);
		}
	}
}
