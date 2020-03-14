using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/decode-string/
	///		Submission: https://leetcode.com/submissions/detail/239753149/
	/// </summary>
	internal class P0394
	{
		public string DecodeString(string s)
		{
			var st = new Stack<List<char>>();
			var sti = new Stack<int>();

			var current = new List<char>();

			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '[')
				{
					current = new List<char>();
					continue;
				}

				if (s[i] == ']')
				{
					var mult = sti.Pop();
					var inner = new List<char>();
					for (int j = 0; j < mult; j++)
						inner.AddRange(current);

					current = st.Pop();
					current.AddRange(inner);
					continue;
				}

				if (char.IsLetter(s[i]))
				{
					current.Add(s[i]);
				}
				else
				{
					var ci = i;
					while (s[ci + 1] != '[')
						ci++;

					st.Push(current);
					sti.Push(int.Parse(s.Substring(i, ci - i + 1)));

					i += ci - i;
				}
			}

			return new string(current.ToArray());
		}
	}
}
