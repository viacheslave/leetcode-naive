using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/string-without-aaa-or-bbb/
  ///    Submission: https://leetcode.com/submissions/detail/243526559/
  /// </summary>
  internal class P0984
  {
		public string StrWithout3a3b(int A, int B)
	  {
			var map = new Dictionary<char, int>() { ['a'] = A, ['b'] = B   };

			var sb = new StringBuilder();

			while (map['a'] > 0 || map['b'] > 0)
		  {
				if (map['a'] == map['b'])
			  {
					Append(map, sb, 'a', 1);
					Append(map, sb, 'b', 1);
					continue;
				}

				if (map['a'] > map['b'])
			  {
					Append(map, sb, 'a', 2);
					Append(map, sb, 'b', 1);
					continue;
				}

				if (map['a'] < map['b'])
			  {
					Append(map, sb, 'b', 2);
					Append(map, sb, 'a', 1);
				}
			}

			return sb.ToString();
		}

		private static void Append(Dictionary<char, int> map, StringBuilder sb, char ch, int count)
	  {
			int index = 0;
			while (index < count && map[ch] > 0)
		  {
				sb.Append(ch);
				map[ch]--;
				index++;
			}
		}
	}
}
