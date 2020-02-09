using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reverse-vowels-of-a-string/
	///		Submission: https://leetcode.com/submissions/detail/228450543/
	/// </summary>
	internal class P0345
	{
		public string ReverseVowels(string s)
		{
			if (s.Length < 2)
				return s;

			var vowels = new HashSet<char>(
					new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }
			);


			int i = 0, j = s.Length - 1;

			var sb = s.ToCharArray();

			while (i < j)
			{
				if (!vowels.Contains(sb[i]))
				{
					i++;
					continue;
				}

				if (!vowels.Contains(sb[j]))
				{
					j--;
					continue;
				}

				var temp = sb[i];
				sb[i] = sb[j];
				sb[j] = temp;

				i++;
				j--;
			}

			return new string(sb);
		}
	}
}
