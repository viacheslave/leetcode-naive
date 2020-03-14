using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-number-of-occurrences-of-a-substring/
	///		Submission: https://leetcode.com/submissions/detail/291110172/
	/// </summary>
	internal class P1297
	{
		public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
		{
			Dictionary<string, int> pool = new Dictionary<string, int>();

			for (var start = 0; start < s.Length; start++)
			{
				var map = new HashSet<char>();

				for (int i = 0; i < minSize - 1; i++)
					if (start + i < s.Length)
						map.Add(s[start + i]);

				for (var length = minSize; length <= maxSize; length++)
				{
					if (start + length > s.Length)
						break;

					map.Add(s[start + length - 1]);
					if (map.Count > maxLetters)
						break;

					var sub = s.Substring(start, length);
					if (!pool.ContainsKey(sub))
						pool[sub] = 1;
					else
						pool[sub]++;
				}
			}

			if (pool.Count == 0)
				return 0;

			return pool.Values.Max();
		}
	}
}
