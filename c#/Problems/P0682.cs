using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/baseball-game/
	///		Submission: https://leetcode.com/submissions/detail/234436074/
	/// </summary>
	internal class P0682
	{
		public int CalPoints(string[] ops)
		{
			List<int> sc = new List<int>();

			for (var i = 0; i < ops.Length; i++)
			{
				if (ops[i] == "C")
				{
					sc.RemoveAt(sc.Count - 1);
					continue;
				}

				if (ops[i] == "D")
				{
					var tmp = sc.Count > 0 ? sc[sc.Count - 1] : 0;

					sc.Add(tmp * 2);
					continue;
				}

				if (ops[i] == "+")
				{
					var tmp = 0;

					if (sc.Count > 0)
						tmp = tmp + sc[sc.Count - 1];

					if (sc.Count > 1)
						tmp = tmp + sc[sc.Count - 2];

					sc.Add(tmp);
					continue;
				}

				sc.Add(int.Parse(ops[i]));
			}

			return sc.Sum();
		}
	}
}
