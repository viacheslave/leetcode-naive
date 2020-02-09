using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reconstruct-original-digits-from-english/
	///		Submission: https://leetcode.com/submissions/detail/242482695/
	/// </summary>
	internal class P0423
	{
		public string OriginalDigits(string s)
		{
			var map = s.ToCharArray().GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count());
			var sb = new StringBuilder();

			var result = Parse(map, sb);
			return result;
		}

		private string Parse(Dictionary<char, int> map, StringBuilder sb)
		{
			var d = new List<(int n, char anc, string value)>()
				{
						(0, 'z', "zero"),
						(2, 'w', "two"),
						(4, 'u', "four"),
						(5, 'f', "five"),
						(7, 'v', "seven"),
						(6, 's', "six"),
						(3, 'r', "three"),
						(8, 'h', "eight"),
						(9, 'i', "nine"),
						(1, 'o', "one"),
				};

			var resMap = new SortedDictionary<int, int>();

			for (int i = 0; i < d.Count; i++)
			{
				var (n, anc, value) = d[i];

				while (map.ContainsKey(anc))
				{
					foreach (var ch in value)
					{
						map[ch]--;
						if (map[ch] == 0) map.Remove(ch);
					}

					if (!resMap.ContainsKey(n))
						resMap[n] = 0;

					resMap[n]++;
				}
			}

			foreach (var mapItem in resMap)
			{
				if (mapItem.Value > 0)
				{
					var str = new string(char.Parse(mapItem.Key.ToString()), mapItem.Value);
					sb.Append(str);
				}
			}

			return sb.ToString();
		}
	}
}
