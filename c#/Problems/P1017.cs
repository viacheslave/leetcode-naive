using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/convert-to-base-2/
	///		Submission: https://leetcode.com/submissions/detail/243275535/
	/// </summary>
	internal class P1017
	{
		public string BaseNeg2(int N)
		{
			if (N == 0) return "0";

			var map = new Dictionary<int, int>();
			var pos = 0;

			while (N > 0)
			{
				var digit = N % 2;

				if (digit == 1)
					IncDigit(map, pos);

				N >>= 1;
				pos++;
			}

			var ch = new char[map.Keys.Max() + 1];
			for (int i = 0; i < ch.Length; i++)
			{
				ch[ch.Length - i - 1] = (map.ContainsKey(i) && map[i] == 1) ? '1' : '0';
			}

			return new string(ch);
		}

		private static void IncDigit(Dictionary<int, int> map, int pos)
		{
			if (!map.ContainsKey(pos))
				map[pos] = 0;

			if (pos % 2 == 0)
			{
				map[pos]++;
				IncLeft(map, pos);
			}

			if (pos % 2 == 1)
			{
				if (map[pos] == 0)
				{
					map[pos]++;
					IncLeft(map, pos);

					if (!map.ContainsKey(pos + 1))
						map[pos + 1] = 0;

					map[pos + 1]++;
					IncLeft(map, pos + 1);
				}
				else
				{
					map[pos]--;
				}
			}
		}

		private static void IncLeft(Dictionary<int, int> map, int pos)
		{
			if (map[pos] == 2)
			{
				map[pos] = 0;
				IncDigit(map, pos + 1);

				IncLeft(map, pos + 1);
			}
		}
	}
}
